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
    Console console;
    public GameObject DialogueManager;
    public GameObject CheckConsole;


    public CinemachineVirtualCamera camera;
    CinemachinePOV pov;
    int pauseCameraValue = 1;

    [Header("HeartBeatSystem")]
    public float HeartBeat;
    public TextMeshProUGUI HeartRateText;
    public bool PlayerDead;
    public float DecreasePerSecond;
    // Start is called before the first frame update
    private void Awake()
    {
        pov = camera.GetCinemachineComponent<CinemachinePOV>();
        inputManager = GetComponent<InputManager>();
        playerLocomation = GetComponent<PlayerLocomation>();
        dialogueManager = DialogueManager.GetComponent<DialogueManager>();
        console = CheckConsole.GetComponent<Console>();
        pov.m_HorizontalAxis.m_MaxSpeed = 100;
        pov.m_VerticalAxis.m_MaxSpeed = 100;
    }

    private void Update()
    {
        HeartBeat -= DecreasePerSecond * Time.deltaTime;
        inputManager.HandleAllInputs();
        HeartRateText.text = "Heart Rate: "+ HeartBeat;
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
    }

    private void FixedUpdate()
    {
        if (dialogueManager.dialogueIsPlaying == true)
        {
            return;
        }
        else
        {
            playerLocomation.HandleAllMovement();
        }


    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        HeartBeat = other.HeartBeatInc + other.HeartBeatDec;
    //        Debug.Log(HeartBeat);
    //    }
    //}



}   
