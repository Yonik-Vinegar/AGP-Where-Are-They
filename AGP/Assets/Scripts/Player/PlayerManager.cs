using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomation playerLocomation;
    DialogueManager dialogueManager;
    public GameObject DialogueManager;

    [Header("HeartBeatSystem")]
    public int HeartBeat;
    public TextMeshProUGUI HeartRateText;

    // Start is called before the first frame update
    private void Awake()
    {

        inputManager = GetComponent<InputManager>();
        playerLocomation = GetComponent<PlayerLocomation>();
        dialogueManager = DialogueManager.GetComponent<DialogueManager>();
        
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
        HeartRateText.text = "Heart Rate: "+ HeartBeat;
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
