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

    public void Awake()
    {
        inputManager = GetComponent<InputManager>();

    }
    // Update is called once per frame
    private void Update()
    {
        if (inputManager.InteractionPerformed == true)
        {
            if (Interactable == null)
            {
                //not carrying an object, try to grab

                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, InteractionLayerMask))
                {

                    Debug.Log("DetectingInteractionavailbility");
                    if (raycastHit.transform.TryGetComponent(out Interactable))
                    {
                        Debug.Log("InteractionAvailable");
                    }
                }
            }
            else
            {
                Interactable = null;
            }
        }
    }
}
