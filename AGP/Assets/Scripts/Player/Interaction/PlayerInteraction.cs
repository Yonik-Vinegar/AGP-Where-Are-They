using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //public float playerReach = 3f;
    //Interactable currentInteractable;
    //InputManager PlayerInput;
    //private void Awake()
    //{
    //    PlayerInput = GetComponent<InputManager>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    CheckInteraction();
    //    if (InteractPressed = true) && currentInteractable != null)
    //    {
    //        currentinteractable.Interact();
    //    }
    //}

    //void CheckInteraction()
    //{
    //    RaycastHit hit;
    //    Ray ray = new Ray(Camera.main.transform.position,Camera.main.transform.forward);
    //    if (Physic.Raycast(ray, out hit, playerReach))
    //    {
    //        if (hit.collider.tag == "Interactable")
    //        {
    //            Interactable newInteractable = hit.collider.GetComponenet<currentInteractable>();
    //            if (currentInteractable && SetNewCurrentInteractable != currentInteractable)
    //            {
    //                currentInteractable.DisableJunction();
    //            }

    //            if (newInteractable.enabled)
    //            {
    //                SetNewCurrentInteractable(newInteractable);
    //            }
    //            else
    //            {
    //                DisableCurrentInteractable();
    //            }
    //        }
    //        else
    //        {
    //            DisableCurrentInteractable();
    //        }
    //    }

    //    else
    //    {
    //        DisableCurrentInteractable();
    //    }
    //}

    //void SetNewCurrentInteractable(Interactable newInteractable)
    //{
    //    currentInteractable = newInteractable;
    //    currentInteractable.EnableJunction();
    //}

    //void DisableCurrentInteractable()
    //{
    //    if (currentInteractable)
    //    {
    //        currentInteractable.DisableJunction();
    //        currentInteractable = null;
    //    }
    //}
}
