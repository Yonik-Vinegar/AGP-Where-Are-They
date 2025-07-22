using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    Interaction interaction;
    InputManager inputManager;
    PlayerManager playerManager;

    [Header("Ink Json")]
    [SerializeField] private TextAsset inkJSON;
    public GameObject Player;
    [SerializeField] private AudioClip[] grdDialogueAudioClips;
    public bool DialogueInteractionTriggered;
    public bool PuzzleInteractionTriggered;
    public bool ContinueDialogueTriggered;
    public bool GroundContinueDialogue;
    public bool LockInputs;
    public bool IsRobot;

    [Header("For Consoles")]
    public bool isConsole;
    public bool HasbeenSolved;
    Console console;
    [SerializeField] private TextAsset UnsolvedJSON;
    [SerializeField] private AudioClip[] UnsolvedAudioClips;

    public Animator RobotAnim;
    
    //public GameObject DialogueManager

    private void Awake()
    {
        Player = GameObject.Find("PlayerManager/Player");
        interaction = Player.GetComponent<Interaction>();
        inputManager = Player.GetComponent<InputManager>();
        playerManager = Player.GetComponent<PlayerManager>();
        console = GetComponent<Console>();
    }

    private void Update()
    {
        if (isConsole)
        {
            HasbeenSolved = console.CanActivate;
        }
        if (!DialogueManager.GetInstance().dialogueIsPlaying)   
        {
            if (DialogueInteractionTriggered == true && isConsole == false)
            {
                DialogueManager.GetInstance().EnterDialogueMode( inkJSON, grdDialogueAudioClips);
                Debug.Log("DialogueTriggered");
            }
            else if (DialogueInteractionTriggered == true && isConsole == true) 
            {
                if (HasbeenSolved == true)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON, grdDialogueAudioClips);
                    Debug.Log("DialogueTriggered");
                }
                else  
                {
                    DialogueManager.GetInstance().EnterConsoleDialogueMode(UnsolvedJSON, UnsolvedAudioClips);
                    Debug.Log("DialogueTriggered");
                }

            }
        }

    }
    public void DialogueInteraction()
    {
        if (inputManager.InteractionPerformed == true)
        {
            DialogueInteractionTriggered = true;
            interaction.KeyCue.SetActive(false);
            interaction.ContinueCue.SetActive(true);
            playerManager.LockInputs = LockInputs;
            if (IsRobot)
            {
                RobotAnim.SetTrigger("Trigger");
            }
        }
        else 
        { 
            DialogueInteractionTriggered = false;
        }

    }
}
