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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            connectedJunction.outputCollider = true;
            connectedJunction.inputCollider = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            connectedJunction.outputCollider = false;
            connectedJunction.inputCollider = false;

        }
    }




}
