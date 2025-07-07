using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;
    private AudioClip[] dialogueClips;
    private int dialogueIndex;
    private AudioSource audioSource;

    private bool RobotAnimation = false;
    private bool audioPlaying = false;

    public bool dialogueIsPlaying { get; private set; }
    PlayerManager playerManager;

    private static DialogueManager instance;
    [Header("Retrieving Input From")]
    public GameObject Player;
    Interaction interaction;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Dialogue Manager");
        }
        instance = this;
        Player = GameObject.Find("PlayerManager/Player");
        audioSource = Player.GetComponent<AudioSource>();
        interaction = Player.GetComponent<Interaction>();
        playerManager = Player.GetComponent<PlayerManager>();
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (interaction.ContinueDialogueTriggered == true || interaction.GroundContinueDialogue)
        {
            ContinueStory();
        }
        if (playerManager.PlayerDead == true)
        {
            audioSource.mute = true;
        }
        if(audioPlaying == true)
        {
            if (!audioSource.isPlaying) 
            {
                dialogueIndex++;
            }

        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, AudioClip[] newDialogueClips)
    {
        currentStory =  new Story (inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        LoadAudioVariables(newDialogueClips);
        ContinueStory();
        
    }

    public void EnterCorridorDialogueMode(TextAsset inkJSON, AudioClip[] newDialogueClips)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        LoadAudioVariables(newDialogueClips);
        ContinueStory();
        RobotAnimation = true;

    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        interaction.ContinueCue.SetActive(false);
        playerManager.LockInputs = false;
        RobotAnimation = false;
        audioPlaying = false;

    }

    private void LoadAudioVariables(AudioClip[] newDialogueClips)
    {
        dialogueClips = newDialogueClips;
        dialogueIndex = 0;
    }

    private void ContinueStory()
    {
        if (RobotAnimation == false) 
        {
            if (currentStory.canContinue)
            {
                dialogueText.text = currentStory.Continue();
                audioSource.Stop();
                audioSource.PlayOneShot(dialogueClips[dialogueIndex]);
                dialogueIndex++;
                Debug.Log("Does this work?");
            }
            else
            {
                ExitDialogueMode();

            }
        }

        if (RobotAnimation == true)
        {
            if (currentStory.canContinue)
            {
                dialogueText.text = currentStory.Continue();
                audioSource.Stop();
                audioSource.PlayOneShot(dialogueClips[dialogueIndex]);
                dialogueIndex++;
                audioPlaying = true;
            }
            else
            {
                ExitDialogueMode();

            }
        }
    }
}
