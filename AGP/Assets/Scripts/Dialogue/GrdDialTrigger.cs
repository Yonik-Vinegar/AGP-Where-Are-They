using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrdDialTrigger : MonoBehaviour
{
    //Code is a modified script from https://www.youtube.com/watch?v=vY0Sk93YUhA&list=PLkz5NgoW6xcWtxugVBcK58aIHpxyjjCSE&index=3
    PlayerManager playerManager;
    Interaction interaction;
    private bool PlayerInRange;
    private bool RobotInRange;
    public GameObject Player;
    [SerializeField] private AudioClip[] grdDialogueAudioClips;
    [SerializeField] private AudioClip SFX;
    public bool ToggleInputs;
    public bool CorridorAnimation;
    public bool FinalRobotCorridorTrigger;
    public GameObject Robot;
    PlayerLocomation playerLocomation;
    public bool FirstTrigger;

    private AudioSource SFXaudioSource;
    public GameObject SFXObject;

    [Header("Ink Json")]
    [SerializeField] private TextAsset inkJSON;
    private void Awake()
    {
        PlayerInRange = false;
        RobotInRange = false;
        Player = GameObject.Find("PlayerManager/Player");
        playerManager = Player.GetComponent<PlayerManager>();
        SFXaudioSource = SFXObject.GetComponent<AudioSource>();
        playerLocomation = Player.GetComponent<PlayerLocomation>();
        interaction = Player.GetComponent<Interaction>();
    }

    private void Update()
    {
                if (!DialogueManager.GetInstance().dialogueIsPlaying)
                {
                    if (CorridorAnimation == false)
                    {
                        if (PlayerInRange == true && playerManager.PlayerDead == false)
                        {
                            DialogueManager.GetInstance().EnterDialogueMode(inkJSON, grdDialogueAudioClips);
                            Debug.Log("DialogueTriggered");
                            Destroy(gameObject);
                            interaction.ContinueCue.SetActive(true);
                            if (FirstTrigger == true)
                            {
                                 SFXaudioSource.PlayOneShot(SFX);
                            }

                        }
                    }

                    if (CorridorAnimation == true)
                    {
                        if (RobotInRange == true && playerManager.PlayerDead == false)
                        {
                         DialogueManager.GetInstance().EnterCorridorDialogueMode(inkJSON, grdDialogueAudioClips);
                         Debug.Log("DialogueTriggered");
                         Destroy(gameObject);
                         interaction.ContinueCue.SetActive(true);

                        }
                    }
                }

                if (RobotInRange == true)
                {
                    playerManager.LockInputs = ToggleInputs;
                    playerLocomation.movementSpeed = 0f;
                }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (playerManager.PlayerDead == false && CorridorAnimation == false && FinalRobotCorridorTrigger == false)
            {
                
                PlayerInRange = true;
            }
            else
            {
                PlayerInRange = false;

            }

            if (CorridorAnimation == true && playerManager.PlayerDead == false)
            {
                Debug.Log("TriggeredCorridorAnim");
                RobotInRange = true;
            }

            else
            {
                RobotInRange = false;
            }
        }

        if (collider.gameObject.tag == "Robot")
        {

            if (FinalRobotCorridorTrigger == true)
            {
                playerLocomation.movementSpeed = 7f;
                playerManager.LockInputs = ToggleInputs;
                PlayerInRange = true;
            }
            else
            {
                PlayerInRange= false;
            }

        }

    }

    private void OnTriggerExit(Collider collider)
    {
        PlayerInRange = false;
        RobotInRange= false;
        Destroy(gameObject);
    }
}
