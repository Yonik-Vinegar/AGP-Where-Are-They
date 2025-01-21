using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrdDialTrigger : MonoBehaviour
{
    private bool PlayerInRange;
    Interaction interaction;
    public GameObject Player;
    [SerializeField] private AudioClip[] grdDialogueAudioClips;

    [Header("Ink Json")]
    [SerializeField] private TextAsset inkJSON;
    private void Awake()
    {
        PlayerInRange = false;
        Player = GameObject.Find("PlayerManager/Player");
        interaction = Player.GetComponent<Interaction>();
    }

    private void Update()
    {
        {
            if (!DialogueManager.GetInstance().dialogueIsPlaying)
            {
                if (PlayerInRange == true)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON, grdDialogueAudioClips);
                    Debug.Log("DialogueTriggered");
                    Destroy(gameObject);
                    interaction.ContinueCue.SetActive(true);
                }

            }

        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = true;

        }
    }

    private void OnTriggerExit(Collider collider)
    {
        PlayerInRange = false;
    }
}
