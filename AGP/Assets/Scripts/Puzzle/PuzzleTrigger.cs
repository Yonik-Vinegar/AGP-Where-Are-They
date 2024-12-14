using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField] bool outTrigger;
    [SerializeField] Junction connectedJunction;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            if (outTrigger)
            {
                connectedJunction.outputCollider = true;
            }
            else
            {
                connectedJunction.inputCollider = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            if (outTrigger)
            {
                connectedJunction.outputCollider = false;
            }
            else
            {
                connectedJunction.inputCollider = false;
            }
        }
    }




}
