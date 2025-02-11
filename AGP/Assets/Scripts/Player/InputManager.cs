using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerInputs PlayerControls;
    [Header("Other checks")]
    public bool lockCursor = true;
    public Vector3 movementInput;
    public Vector2 cameraInput;
    public bool InteractPressed = false;
    public bool InteractionPerformed;
    private bool ContinuePerformed = false;
    public bool ContinuePressed;
    private bool PausePerformed;
    public bool PausePressed;
    [Header("Idle settings")]
    public float IdleTimer = 5;
    public bool PlyIdleAvailble;
    public bool PlyIdleEnabled;
    private bool PlyIdleUNAvailble;
    private float IdleTimerDecrease = 1;
    [Header("MovementInputs")]
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
            PlayerControls.MovementActions.MovementInputs.performed += i => PlyIdleUNAvailble = true;
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
        IdleTrigger();
        if (PlyIdleUNAvailble == true)
        {
            PlyIdleAvailble = false;
        }
        else
        {
            PlyIdleAvailble = true;
        }
    
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
                PlyIdleAvailble = false;
            }
            else
            {
                InteractionPerformed = false;
                PlyIdleAvailble = true;
            }

            if (ContinuePerformed == true)
            {
                ContinuePressed = true;
                ContinuePerformed = false;
                PlyIdleAvailble = false;

            }
            else
            {
                ContinuePressed = false;
                PlyIdleAvailble = true;
            }
        }
        if (PausePerformed == true)
        {
            PausePressed = true;
            PausePerformed = false;
            PlyIdleAvailble = false;

        }
        else
        {
            PausePressed = false;
        }
    }

    public void IdleTrigger()
    {
        if (PlyIdleAvailble == true)
        {
            IdleTimer -= IdleTimerDecrease * Time.deltaTime;
            if (IdleTimer <= 0)
            {
                PlyIdleEnabled = true;
            }
            else { PlyIdleEnabled = false; }


        }
        else
        {
            IdleTimer = 5;
        }

        if (verticalInput >= 0)
        {
            PlyIdleAvailble = false;
        }
        else if (horizontalInput >= 0) 
        { 
            PlyIdleAvailble = false; 
        }
        else { PlyIdleAvailble = true; }


    }


}
