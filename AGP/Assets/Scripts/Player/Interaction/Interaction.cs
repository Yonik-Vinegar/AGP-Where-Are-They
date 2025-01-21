using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask InteractionLayerMask;
    //[SerializeField] private Transform objectGrabPointTransform;
    InputManager inputManager;
    private Interactable Interactable;
    public bool DialogueInteractionTriggered;
    public bool PuzzleInteractionTriggered;
    public bool ContinueDialogueTriggered;
    public bool GroundContinueDialogue;


    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private GameObject KeyCue;
     public GameObject ContinueCue;
    //[Header("Deciding which interaction to follow")]
    //[SerializeField] private GameObject[] junction;

    public void Awake()
    {
        inputManager = GetComponent<InputManager>();
        visualCue.SetActive(false);
        KeyCue.SetActive(false);
        ContinueCue.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Interactable == null) // do it via pressed then in the actual compare tags of raycast set to triggerd
        {
            RaycastHit hit;
             float Distance = 5f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, Distance, InteractionLayerMask))
            {
                visualCue.SetActive(true);
                KeyCue.SetActive(true);
                
                if (hit.transform.CompareTag("Robot"))
                {
                    Debug.Log("picking up the robot");
                    DialogueInteraction();

                }

                if (inputManager.InteractionPerformed) //Maxim helped with these if statement sections sections.
                {
                    if (hit.collider.TryGetComponent(out MainJunctionScript junction))
                    {
                        Debug.Log("picking up the junctions");
                        junction.Interact();
                    }

                    if (hit.collider.TryGetComponent(out Console consoleScript))
                    {
                        Debug.Log("Receving the raycast hit");
                        if (consoleScript.CanActivate == true)
                        {
                            consoleScript.ConsoleTrigger();
                        }
                    }
                }



            }
            else
            {
                visualCue.SetActive(false);
                KeyCue.SetActive(false);
            }
        }

        else
        {
            Interactable = null;
        }

        if (inputManager.ContinuePressed == true)
        {
            GroundContinueDialogue = true;
            Debug.Log("is this continously saying yes");

        }
        else { GroundContinueDialogue = false; }

    }

    private void DialogueInteraction()
    {
        if (inputManager.InteractionPerformed == true)
        {
            DialogueInteractionTriggered = true;
            KeyCue.SetActive(false);
            ContinueCue.SetActive(true);
        }
        else { DialogueInteractionTriggered= false; }

        if (inputManager.ContinuePressed == true)
        {
            ContinueDialogueTriggered = true;
            ContinueCue.SetActive(true);
        }
        else {  ContinueDialogueTriggered= false; }
    }
    
}
