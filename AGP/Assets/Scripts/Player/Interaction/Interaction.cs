using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask InteractionLayerMask;
    InputManager inputManager;
    private Interactable Interactable;
    public bool InteractionTriggered;
    public bool ContinueTriggered;

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
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, Distance, InteractionLayerMask))
            {
                visualCue.SetActive(true);
                if (inputManager.InteractionPerformed == true)
                {
                    Debug.Log("Is InteractionTriggered being set to true");
                    InteractionTriggered = true;
                }
                else
                {

                    InteractionTriggered = false;
                }

                if (inputManager.ContinuePerformed == true)
                {
                    Debug.Log("Is ContinueTriggered being called more than once");
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
