using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomation playerLocomation;
    CameraManager cameraManager;
    DialogueManager dialogueManager;
    public GameObject DialogueManager;
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



}   
