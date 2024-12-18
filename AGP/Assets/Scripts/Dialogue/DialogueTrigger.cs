using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    Interaction interaction;

    [Header("Ink Json")]
    [SerializeField] private TextAsset inkJSON;
    public GameObject Player;
    //public GameObject DialogueManager

    private void Awake()
    {
        Player = GameObject.Find("PlayerManager/Player");
        interaction = Player.GetComponent<Interaction>();
    }

    private void Update()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)   
        {
            if (interaction.DialogueInteractionTriggered == true)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                Debug.Log("DialogueTriggered");
            }
        }

    }

}
