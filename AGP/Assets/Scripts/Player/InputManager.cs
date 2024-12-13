using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerInputs PlayerControls;

    //Standard player variables
    public Vector2 movementInput;
    public Vector2 cameraInput;
    private bool InteractPressed = false;
    public bool InteractionPerformed;
    public bool ContinuePerformed;
    private bool ContinuePressed = false;

    //Camera Variables
    public float verticalInput;
    public float horizontalInput;
    public float cameraInputY;
    public float cameraInputX;

    //UI variables
    public Vector2 UIMovementInput;
    public bool UISubmitPressed = false;

    private void OnEnable()
    {
        if (PlayerControls == null)
        {
            PlayerControls = new PlayerInputs();
            PlayerControls.MovementActions.MovementInputs.performed += i => movementInput = i.ReadValue<Vector2>();
            PlayerControls.MovementActions.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            PlayerControls.InteractionActionMap.Interact.performed += i => InteractPressed = true;
            PlayerControls.InteractionActionMap.Continue.performed += i => ContinuePressed = true;
            PlayerControls.UIActionMap.Move.performed += i => UIMovementInput = i.ReadValue<Vector2>();
            PlayerControls.UIActionMap.Submit.performed += i => UISubmitPressed = true;
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

    public void Update()
    {
        if (InteractPressed == true)
        {
            InteractionPerformed = true;
            InteractPressed = false;
        }
        else
        {
            InteractionPerformed = false;
        }

        if (ContinuePressed == true)
        {
            Debug.Log("Registering space");
            ContinuePerformed = true;
            ContinuePressed = false;
        }
        else
        {
            ContinuePerformed = false;
        }

    }


}
