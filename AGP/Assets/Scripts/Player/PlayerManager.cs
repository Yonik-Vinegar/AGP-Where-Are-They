using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomation playerLocomation;
    DialogueManager dialogueManager;
    Interaction interaction;
    Console console;
    public GameObject DialogueManager;
    public GameObject CheckConsole;

    [Header("Camera Systems")]
    public CinemachineVirtualCamera camera;
    CinemachinePOV pov;
    int pauseCameraValue = 1;
    public bool LockInputs;

    [Header("HeartBeatSystem")]
    public float HeartBeat;
    public TextMeshProUGUI HeartRateText;
    public bool PlayerDead;
    public float DecreasePerSecond;

    [Header("HeartBeat UI")]
    public GameObject HeartRateFine;
    public GameObject HeartRateCaution;
    public GameObject HeartRateDanger;
    [Header("HeartBeat SFX")]
    private AudioSource audioSource;
    public GameObject FineHeartObject;
    public GameObject CautionHeartObject;
    public GameObject DangerHeartObject;
    public GameObject FlatlineObject;
    private bool FineHeart = false;
    private bool CautionHeart = false; 
    private bool DangerHeart = false;   

    // Start is called before the first frame update
    private void Awake()
    {
        pov = camera.GetCinemachineComponent<CinemachinePOV>();
        inputManager = GetComponent<InputManager>();
        playerLocomation = GetComponent<PlayerLocomation>();
        interaction = GetComponent<Interaction>();
        dialogueManager = DialogueManager.GetComponent<DialogueManager>();
        console = CheckConsole.GetComponent<Console>();
        pov.m_HorizontalAxis.m_MaxSpeed = .1f;
        pov.m_VerticalAxis.m_MaxSpeed = .1f;
        HeartRateCaution.SetActive(false); HeartRateDanger.SetActive(false);
        CautionHeartObject.SetActive(false); DangerHeartObject.SetActive(false); FlatlineObject.SetActive(false);

    }

    private void Update()
    {
        HeartBeat -= DecreasePerSecond * Time.deltaTime;
        inputManager.HandleAllInputs();
        HeartRateText.text = "Heart Rate: "+ Mathf.RoundToInt(HeartBeat);
        if (HeartBeat >= 120f)
        {
            PlayerDead = true;
            FlatlineObject.SetActive(true);
            console.EndGame();
            HeartRateFine.SetActive(false);
            HeartRateCaution.SetActive(false);
            HeartRateDanger.SetActive(false);
            DangerHeartObject.SetActive(false);
            CautionHeartObject.SetActive(false);
            FineHeartObject.SetActive(false);
        }
        else { PlayerDead = false; }
        if (HeartBeat <= 80f)
        {
            HeartBeat = 80f;
        }

        if (HeartBeat >= 80f && HeartBeat <= 95f && FineHeart == false)
        {
            HeartRateFine.SetActive(true);
            HeartRateCaution.SetActive(false);
            HeartRateDanger.SetActive(false);
            DangerHeartObject.SetActive(false);
            CautionHeartObject.SetActive(false);
            FineHeartObject.SetActive(true);
            FineHeart = true;
            CautionHeart = false;
            DangerHeart = false;
        }

        if (HeartBeat >= 96f && HeartBeat <= 105f && CautionHeart == false)
        {
            HeartRateFine.SetActive(false);
            HeartRateCaution.SetActive(true);
            HeartRateDanger.SetActive(false );
            DangerHeartObject.SetActive(false);
            CautionHeartObject.SetActive(true);
            FineHeartObject.SetActive(false);
            CautionHeart = true;
            FineHeart = false;
            DangerHeart = false;
        }

        if (HeartBeat >= 106f && HeartBeat < 120f && DangerHeart == false)
        {
            HeartRateFine.SetActive(false);
            HeartRateCaution.SetActive(false);
            HeartRateDanger .SetActive(true);
            DangerHeartObject.SetActive(true);
            CautionHeartObject.SetActive(false);
            FineHeartObject.SetActive(false);
            DangerHeart = true;
            FineHeart = false;
            CautionHeart = false;
        }

        HandleMouseMomentum();
    }

    private void HandleMouseMomentum()
    {
        LockInputs = inputManager.pauseMenu.isPaused;
        Debug.Log(LockInputs);
        if (LockInputs)
        {
        }
        else
        {
        }
    }

    private void FixedUpdate()
    {
        playerLocomation.HandleAllMovement();
        
    }


}   
