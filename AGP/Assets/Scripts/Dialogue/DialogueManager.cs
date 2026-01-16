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

    public bool dialogueIsPlaying { get; private set; }
    PlayerManager playerManager;

    private static DialogueManager instance;
    [Header("Retrieving Input From")]
    public GameObject Player;
    Interaction interaction;

    [Header("Final Console")]
    public GameObject FinalConsole;
    Console console;

    private bool OnGroundDialogue;
    
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
        console = FinalConsole.GetComponent<Console>();
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
        if (dialogueIsPlaying)
        {
            CheckForDialogueLoad();
        }
        
    }

    private void CheckForDialogueLoad()
    {
        if (interaction.ContinueDialogueTriggered == true || interaction.GroundContinueDialogue || OnGroundDialogue && !audioSource.isPlaying)
        {
            ContinueStory();
        }
        if (playerManager.PlayerDead)
        {
            audioSource.mute = true;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, AudioClip[] newDialogueClips, bool GroundDialogue, bool triggerRobotAnimation)
    {
        currentStory =  new Story (inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        LoadAudioVariables(newDialogueClips);
        if (GroundDialogue)
        {
            OnGroundDialogue = true;
        }
        ContinueStory();
        console.Dialogueplaying = true;
        RobotAnimation = triggerRobotAnimation;
    }

    public void EnterConsoleDialogueMode(TextAsset UnsolvedJSON, AudioClip[] newDialogueClips)
    {
        currentStory = new Story(UnsolvedJSON.text);
        dialogueIsPlaying = true;
        interaction.ContinueCue.SetActive(true);
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
        console.Dialogueplaying = false;

    }

    private void LoadAudioVariables(AudioClip[] newDialogueClips)
    {
        dialogueClips = newDialogueClips;
        dialogueIndex = 0;
    }

    private bool CheckIfGroundDialogue(bool isGroundDialogue)
    {
        if (isGroundDialogue)
        {
            if (audioSource.isPlaying || !currentStory.canContinue)
            {
                return false;
            }
            return true;
        }
        return currentStory.canContinue;
    }
    
    private void ContinueStory()
    {
        bool canContinue = CheckIfGroundDialogue(OnGroundDialogue);
        if (canContinue)
        {
            dialogueText.text = currentStory.Continue();
            audioSource.Stop();
            audioSource.clip = dialogueClips[dialogueIndex];
            audioSource.Play();
            dialogueIndex++;
            Debug.Log("Does this work?");
        }
        else
        {
            OnGroundDialogue = false;
            ExitDialogueMode();
        }
    }
}
