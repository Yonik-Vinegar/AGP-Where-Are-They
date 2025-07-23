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
    private bool PausePerformed;
    public bool PausePressed;

    public float verticalInput;
    public float horizontalInput;
    public float cameraInputY;
    public float cameraInputX;

    public GameObject FinalConsole;
    Console consoleScript;
    public GameObject GameManager;
    PauseMenu pauseMenu;

    public AudioSource audioSource;
    private bool MovementPerformed;

    [Header("Tutorial things")]
    public GameObject Tutorial1;
    private float LocomotionPerformed = 0;

    private void Start()
    {
        consoleScript = FinalConsole.GetComponent<Console>();
        pauseMenu = GameManager.GetComponent<PauseMenu> ();
        Tutorial1.SetActive (true);
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

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        if (movementInput.x > 0 ||  movementInput.y > 0 || movementInput.x < 0 || movementInput.y < 0)
        {
            MovementPerformed = true;
            LocomotionPerformed++;
        }
        else
        {
            MovementPerformed = false;
        }

    }

    public void Update()
    {
        if (MovementPerformed == true && LocomotionPerformed >= 1)
        {
            Tutorial1.SetActive(false);
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

        if (MovementPerformed == true)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
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
