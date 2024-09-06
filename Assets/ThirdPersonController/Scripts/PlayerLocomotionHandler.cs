using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLocomotionHandler : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private CharacterController characterController; 

    public bool isSprinting;

    [Header("Movement Speeds")]
    public float walkingSpeed = 1.5f;
    public float joggingSpeed = 4f;
    public float sprintingSpeed = 10f;
    public float rotationSpeed = 15f;
    public float gravity = -9.81f; // Gravity value to apply to the player

    private Vector3 moveDirection;
    private Vector3 velocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void HandleAllPlayerMovement()
    {
        HandlePlayerMovement();
        HandlePlayerRotation();
    }

    private void HandlePlayerMovement()
    {
        // Calculate the movement direction based on camera forward and right vectors
        moveDirection = cameraTransform.forward * inputManager.verticalInput;
        moveDirection += cameraTransform.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        // Adjust speed based on sprinting, jogging, or walking
        if (isSprinting)
        {
            moveDirection *= sprintingSpeed;
        }
        else if (inputManager.moveAmount >= 0.5f)
        {
            moveDirection *= joggingSpeed;
        }
        else
        {
            moveDirection *= walkingSpeed;
        }

        // Apply gravity
        if (characterController.isGrounded)
        {
            velocity.y = 0; // Reset vertical velocity when grounded
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Move the character controller
        characterController.Move(moveDirection * Time.deltaTime + velocity * Time.deltaTime);
    }

    private void HandlePlayerRotation()
    {
        // Calculate the target direction based on input and camera forward/right vectors
        Vector3 targetDirection = cameraTransform.forward * inputManager.verticalInput;
        targetDirection += cameraTransform.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        // Rotate smoothly towards the target direction
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}