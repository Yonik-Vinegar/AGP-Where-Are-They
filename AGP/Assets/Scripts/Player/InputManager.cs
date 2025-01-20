using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerInputs PlayerControls;

    public bool lockCursor = true;
    public Vector3 movementInput;
    public Vector2 cameraInput;
    public bool InteractPressed = false;
    public bool InteractionPerformed;
    private bool ContinuePerformed = false;
    public bool ContinuePressed;

    public float verticalInput;
    public float horizontalInput;
    public float cameraInputY;
    public float cameraInputX;

    public GameObject FinalConsole;
    Console consoleScript;

    private void Start()
    {
        consoleScript = FinalConsole.GetComponent<Console>();
    }

    private void OnEnable()
    {
        
        if (PlayerControls == null)
        {
            PlayerControls = new PlayerInputs();
            PlayerControls.MovementActions.MovementInputs.performed += i => movementInput = i.ReadValue<Vector3>();
            PlayerControls.MovementActions.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            PlayerControls.InteractionActionMap.Interact.performed += i => InteractPressed = true;
            PlayerControls.InteractionActionMap.Continue.performed += i => ContinuePerformed = true;
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
        if (consoleScript.GameActive == true)
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

            if (ContinuePerformed == true)
            {
                ContinuePressed = true;
                ContinuePerformed = false;
            }
            else
            {
                ContinuePressed = false;
            }
        }
        if (lockCursor == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}
