using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerLocomotionHandler playerLocomotionHandler;

    public Vector2 movementInput;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;



    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpInput();
        HandleCameraInput();
    }


    private void HandleJumpInput()
    {

    }


    private void HandleMovementInput()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
    }

    private void HandleCameraInput()
    {
        // TODO Move Camera inputs here and connect to cameraManager;
    }

    private void HandleSprintingInput()
    {
        if (Input.GetKey(KeyCode.LeftShift) && moveAmount > 0.5f)
        {
            playerLocomotionHandler.isSprinting = true;
        }
        else
        {
            playerLocomotionHandler.isSprinting = false;
        }
    }


}
