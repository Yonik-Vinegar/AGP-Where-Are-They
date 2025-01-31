using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerInputs PlayerControls;

    public bool lockCursor = true;
    public Vector3 movementInput;
    public bool InteractPressed = false;
    public bool InteractionPerformed;
    private bool ContinuePerformed = false;
    public bool ContinuePressed;
    private bool PausePerformed;
    public bool PausePressed;

    public float verticalInput;
    public float horizontalInput;

    public GameObject FinalConsole;
    Console consoleScript;
    public GameObject GameManager;
    PauseMenu pauseMenu;

    private void Start()
    {
        consoleScript = FinalConsole.GetComponent<Console>();
        pauseMenu = GameManager.GetComponent<PauseMenu> ();
    }

    private void OnEnable()
    {

        if (PlayerControls == null)
        {
            PlayerControls = new PlayerInputs();
            PlayerControls.MovementActions.MovementInputs.performed += i => movementInput = i.ReadValue<Vector3>();
            PlayerControls.InteractionActionMap.Interact.performed += i => InteractPressed = true;
            PlayerControls.InteractionActionMap.Continue.performed += i => ContinuePerformed = true;
            PlayerControls.InteractionActionMap.PauseUI.performed += i => PausePerformed = true;
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


    }

    public void Update()
    {
        if (consoleScript.GameActive == true )
        {
            HandleIFStatements();
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

    private void HandleIFStatements()
    {
        if (pauseMenu.isPaused == false)
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
        if (PausePerformed == true)
        {
            PausePressed = true;
            PausePerformed = false;
        }
        else
        {
            PausePressed = false;
        }
    }


}
