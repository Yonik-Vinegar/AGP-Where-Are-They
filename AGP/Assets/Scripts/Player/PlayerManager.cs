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
    int Sensitivity; 
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
    public GameObject SFXObject;
    [SerializeField] private AudioClip FineHeartbeat;
    [SerializeField] private AudioClip CautionHeartbeat;
    [SerializeField] private AudioClip DangerHeartbeat;
    [SerializeField] private AudioClip Flatline;
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
        pov.m_HorizontalAxis.m_MaxSpeed = 100;
        pov.m_VerticalAxis.m_MaxSpeed = 100;

        HeartRateCaution.SetActive(false);
        HeartRateDanger.SetActive(false);

        audioSource = SFXObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        HeartBeat -= DecreasePerSecond * Time.deltaTime;
        inputManager.HandleAllInputs();
        HeartRateText.text = "Heart Rate: "+ Mathf.RoundToInt(HeartBeat);
        if (HeartBeat >= 120f)
        {
            PlayerDead = true;
            console.EndGame();
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
            audioSource.PlayOneShot(FineHeartbeat);
            FineHeart = true;
            CautionHeart = false;
            DangerHeart = false;
        }

        if (HeartBeat >= 96f && HeartBeat <= 105f && CautionHeart == false)
        {
            HeartRateFine.SetActive(false);
            HeartRateCaution.SetActive(true);
            HeartRateDanger.SetActive(false );
            audioSource.PlayOneShot(CautionHeartbeat);
            CautionHeart = true;
            FineHeart = false;
            DangerHeart = false;
        }

        if (HeartBeat >= 106f && HeartBeat < 120f && DangerHeart == false)
        {
            HeartRateFine.SetActive(false);
            HeartRateCaution.SetActive(false);
            HeartRateDanger .SetActive(true);
            audioSource.PlayOneShot(DangerHeartbeat);
            DangerHeart = true;
            FineHeart = false;
            CautionHeart = false;
        }
    }

    private void FixedUpdate()
    {
        if (LockInputs == false)
        {
            pov.m_HorizontalAxis.m_MaxSpeed = 100;
            pov.m_VerticalAxis.m_MaxSpeed = 100;
            playerLocomation.HandleAllMovement();
        }
        else if (LockInputs == true)
        {
            pov.m_HorizontalAxis.m_MaxSpeed = 0;
            pov.m_VerticalAxis.m_MaxSpeed = 0;
        }
    }

    private void HandleSensitivity()
    {
        if (LockInputs == false)
        {
            //pov.m_HorizontalAxis.m_MaxSpeed = pov.m_HorizontalAxis.m_MaxSpeed * pauseCameraValue;
            //pov.m_VerticalAxis.m_MaxSpeed = pov.m_VerticalAxis.m_MaxSpeed * pauseCameraValue;
            //Have the senstivity slider be its own variable, then have the Sensitivity in this script = it, unless it's being locked, that changed via an if statement.
        }
    }

}   
