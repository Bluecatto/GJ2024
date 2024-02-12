using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift); 

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        float speed = isRunning ? runSpeed : walkSpeed;

        characterController.Move(moveDirection * Time.deltaTime * speed);
    }
}