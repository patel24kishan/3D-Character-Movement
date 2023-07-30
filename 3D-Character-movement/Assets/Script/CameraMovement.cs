using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    [SerializeField] float MoveSpeed=3;
    [SerializeField] float clampRotationInZ = 80f;

    [SerializeField] float MouseDamping=10;

    Vector3 localRot;

    void Update()
    {
        transform.position = player.position;

        localRot.x += Input.GetAxis("Mouse X") * MoveSpeed;
        localRot.y -= Input.GetAxis("Mouse Y") * MoveSpeed;

        localRot.y=Mathf.Clamp(localRot.y, 0f, clampRotationInZ);

        Quaternion quat=Quaternion.Euler(localRot.y,localRot.x,0f);
        transform.rotation = Quaternion.Lerp(transform.rotation,quat,Time.deltaTime*MouseDamping);


    }
}
