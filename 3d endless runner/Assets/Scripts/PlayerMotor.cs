using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update() {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity;
        }
       
        // X = Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Y = Up and Down
        moveVector.y = verticalVelocity;
        // Z = Forward and Backwards
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime); 
    }
}
