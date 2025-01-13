using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainJunctionScript : MonoBehaviour
{
    [SerializeField] private MainJunctionScript previousJunction;
    private bool previousCharged;
    public bool IsCharged;
    public bool[] triggerBools;
    [SerializeField] private bool firstJunction;
    private Quaternion targetRotation;
    private float turnSpeed = 5;
    // Update is called once per frame

    private void Awake()
    {
        targetRotation = transform.rotation;
    }
    void Update()
    {
        CheckPreviousJunction();
        CheckTriggers();
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }


    private void CheckPreviousJunction()
    {
        if (!firstJunction)
        {
            previousCharged = previousJunction.IsCharged;
        }
        else
        {
            previousCharged = true;
        }
    }

    private void CheckTriggers()
    {
        if (previousCharged)
        {
            IsCharged = true;
            foreach (bool triggerBool in triggerBools)
            {
                if (!triggerBool)
                {
                    IsCharged = false;
                }
            }
            
        }
        else
        {
            IsCharged = false;
        }
    }

    public void RotateJunction()
    {
        if (IsCharged == false)
        {
            targetRotation *= Quaternion.AngleAxis(90, Vector3.forward);
        }

    }
    public void Interact()
    {
        Debug.Log("interacting with junction");
        RotateJunction();
    }
}
