using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrdDialTrigger : MonoBehaviour
{
    //Code is a modified script from https://www.youtube.com/watch?v=vY0Sk93YUhA&list=PLkz5NgoW6xcWtxugVBcK58aIHpxyjjCSE&index=3
    PlayerManager playerManager;
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
        playerManager = Player.GetComponent<PlayerManager>();
    }

    private void Update()
    {
        {
                
                if (!DialogueManager.GetInstance().dialogueIsPlaying)
                {
                    if (PlayerInRange == true && playerManager.PlayerDead == false)
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
            if (playerManager.PlayerDead == false)
            {
                PlayerInRange = true;
            }
            else
            {
                PlayerInRange = false;

            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        PlayerInRange = false;
    }
}
