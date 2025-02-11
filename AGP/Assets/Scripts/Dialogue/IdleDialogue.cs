using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleDialogue : MonoBehaviour
{
    InputManager inputmanager;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset[] JsonList;
    public bool DialogueInteractionTriggered;
    public bool PuzzleInteractionTriggered;
    public bool ContinueDialogueTriggered;
    public bool GroundContinueDialogue;
    [SerializeField] private AudioClip[] grdDialogueAudioClips;

    private void Awake()
    {  
        inputmanager = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (inputmanager.PlyIdleEnabled == true)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, grdDialogueAudioClips);
                inkJSON = JsonList[Random.Range(0, JsonList.Length)];
                Debug.Log("DialogueTriggered");
            }
        }

    }
}
