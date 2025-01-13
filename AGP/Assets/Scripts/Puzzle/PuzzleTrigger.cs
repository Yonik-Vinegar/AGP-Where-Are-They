using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{

    [SerializeField] Junction connectedJunction;
    public GameObject AssignedJunction;

    private void Awake()
    {

        connectedJunction = AssignedJunction.GetComponent<Junction>();
    }

    private void Update()
    {
        if (connectedJunction.outputCollider == true && connectedJunction.inputCollider == false)
        {
            connectedJunction.outputCollider = false;
        }
        if (connectedJunction.inputCollider == true && connectedJunction.outputCollider == false)
        {
            connectedJunction.inputCollider = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InPipe"))
        {
            connectedJunction.inputCollider = true;
            Debug.Log("is this activating input");

        }
        if (other.CompareTag("OutPipe"))
        {
            connectedJunction.outputCollider = true;
            Debug.Log("Is this activating output");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InPipe"))
        {
            connectedJunction.inputCollider = false;

        }

        if (other.CompareTag("OutPipe"))
        {
            connectedJunction.outputCollider = false;
        }
    }




}
