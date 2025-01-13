using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private MainJunctionScript previousJunction;
    

    private void Update()
    {
        if (previousJunction.IsCharged)
        {
            Debug.Log("OPEN DOOR");
        }
    }
}
