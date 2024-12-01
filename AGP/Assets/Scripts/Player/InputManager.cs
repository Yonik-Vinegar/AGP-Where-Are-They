using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerInputs PlayerControls;

    public Vector2 movementInput;
    public Vector2 cameraInput;
    public bool InteractPressed;

    public float verticalInput;
    public float horizontalInput;
    public float cameraInputY;
    public float cameraInputX;

    private void OnEnable()
    {
        if (PlayerControls == null)
        {
            PlayerControls = new PlayerInputs();
            PlayerControls.MovementActions.MovementInputs.performed += i => movementInput = i.ReadValue<Vector2>();
            PlayerControls.MovementActions.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            PlayerControls.MovementActions.Interact.performed += i => InteractPressed = true;
        }

        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }
    public void HandleAllInputs()
    {
        HandleInputs();

    }
    void HandleInputs()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;




    }
    

}
