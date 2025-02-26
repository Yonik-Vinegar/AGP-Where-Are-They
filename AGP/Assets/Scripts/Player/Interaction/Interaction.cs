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
    public bool PuzzleInteractionTriggered;
    public bool GroundContinueDialogue;
    public bool ContinueDialogueTriggered;
    public bool ToggleInputs;


    [Header("Visual Cue")]
     public GameObject KeyCue;
     public GameObject ContinueCue;
    //[Header("Deciding which interaction to follow")]
    //[SerializeField] private GameObject[] junction;

    public void Awake()
    {
        inputManager = GetComponent<InputManager>();
        KeyCue.SetActive(false);
        ContinueCue.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        ToggleInputs = false;
        if (Interactable == null) // do it via pressed then in the actual compare tags of raycast set to triggerd
        {
            RaycastHit hit;
             float Distance = 5f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, Distance, InteractionLayerMask))
            {
                KeyCue.SetActive(true);
                
                if (hit.collider.TryGetComponent(out DialogueTrigger dialogueTrigger))
                {
                    Debug.Log("picking up the robot");
                    dialogueTrigger.DialogueInteraction();
                   

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
    public void DialogueInteraction()
    {
        if (inputManager.ContinuePressed == true)
        {
            ContinueDialogueTriggered = true;
            ContinueCue.SetActive(true);
        }
        else { ContinueDialogueTriggered = false; }
    }


}
