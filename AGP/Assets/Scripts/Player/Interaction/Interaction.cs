using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask InteractionLayerMask;
    //[SerializeField] private Transform objectGrabPointTransform;

    private  Interactable interactionAvailable;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactionAvailable == null)
            {
                //not carrying an object, try to grab

                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, InteractionLayerMask))
                {
                    Debug.Log(raycastHit.transform);
                    if (raycastHit.transform.TryGetComponent(out interactionAvailable))
                    {
                        //ObjectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(InteractionAvailable);
                    }
                }
            }
            else
            {
                interactionAvailable = null;
            }
        }
    }
}
