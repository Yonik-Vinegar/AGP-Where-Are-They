using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggers : MonoBehaviour
{
    public Animator eventAnimator;
    public int HeartBeatInc;
    public int HeartBeatDec;
    PlayerManager playerManager;
    public GameObject Player;
    private void Awake()
    {
        playerManager = Player.GetComponent<PlayerManager> ();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerManager.HeartBeat = playerManager.HeartBeat + HeartBeatInc;  
            playerManager.HeartBeat = playerManager.HeartBeat - HeartBeatDec;
            eventAnimator.SetTrigger("EventTrigger");
            Debug.Log(playerManager.HeartBeat);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            eventAnimator.SetTrigger("EventExitTrigger");
        }
    }

   
}
