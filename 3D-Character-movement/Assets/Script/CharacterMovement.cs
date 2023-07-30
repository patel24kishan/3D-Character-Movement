using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] Transform camera;
    [SerializeField] float speed = 10;
    [SerializeField] float jump = 5;




    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal") * speed;
        float yInput = Input.GetAxis("Vertical") * speed;


        // Camera dir
        Vector3 cameraForward = camera.forward;
        Vector3 cameraRight = camera.right;
        cameraForward.y = 0;
        cameraRight.y = 0;



        //relative cam dir
        Vector3 forwardRelative = cameraForward * yInput;
        Vector3 rightRelative = cameraRight * xInput;

        Vector3 relativeMoveDir = forwardRelative + rightRelative;

        //W,A,S,D
        rb.velocity=new Vector3(relativeMoveDir.x, rb.velocity.y, relativeMoveDir.z);

        //Space (to be fixed)
        if(Input.GetButtonDown("Jump") && Mathf.Approximately(rb.velocity.y,0))
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }

        //face Rotation
        transform.forward=new Vector3( rb.velocity.x, 0, rb.velocity.z);
    }
}
