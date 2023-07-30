using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 5f;
    [SerializeField] float turnSmoothTime = 0.5f;
    private float turnVelocityRef;
    private CharacterController characterController;
    public Transform camera;
    private Animator animator;

    void Start()
    {
        characterController= GetComponent<CharacterController>();
        animator= GetComponent<Animator>();
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal") ;
        float yInput = Input.GetAxisRaw("Vertical");
        Vector3 direction=new Vector3(xInput,0f,yInput).normalized;
        float moveAmount= Mathf.Clamp01(Mathf.Abs(xInput)+Mathf.Abs(yInput));
        
        //W,A,S,D
        if (direction.magnitude>=0.1f) {

            float targetAngle=Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg+camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocityRef,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir *speed* Time.deltaTime);
        }
        animator.SetFloat("MoveFlag", moveAmount,0.2f,Time.deltaTime);


        //Jump
        /*if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/

    }
}
