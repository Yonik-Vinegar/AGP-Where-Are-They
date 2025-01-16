using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggers : MonoBehaviour
{
    public Animator eventAnimator;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            eventAnimator.SetTrigger("EventTrigger");
        }
    }

   
}
