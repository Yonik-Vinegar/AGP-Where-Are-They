using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunctionColliderScript : MonoBehaviour
{
    [SerializeField] private MainJunctionScript junctionScript;

    [SerializeField] private int boolNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            junctionScript.triggerBools[boolNumber] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            junctionScript.triggerBools[boolNumber] = false;
        }
    }
}
