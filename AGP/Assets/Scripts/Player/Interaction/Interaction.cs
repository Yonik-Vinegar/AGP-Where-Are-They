using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask InteractionLayerMask;
    //[SerializeField] private Transform objectGrabPointTransform;
    InputManager inputManager;
    private Interactable Interactable;
    public bool InteractionTriggered;
    public bool ContinueTriggered = false;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    public void Awake()
    {
        inputManager = GetComponent<InputManager>();
        visualCue.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Interactable == null)
        {
             float Distance = 5f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, Distance, InteractionLayerMask) && !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                visualCue.SetActive(true);
                if (inputManager.InteractionPerformed == true)
                {
                    InteractionTriggered = true;
                }
                else
                {
                    InteractionTriggered = false;
                }

                if (inputManager.ContinuePressed == true)
                {
                    ContinueTriggered = true;
                }
                else
                {
                    ContinueTriggered = false;
                }
            }
            else
            {
                visualCue.SetActive(false);
            }
        }

        else
        {
            Interactable = null;
        }

        
    }
}
