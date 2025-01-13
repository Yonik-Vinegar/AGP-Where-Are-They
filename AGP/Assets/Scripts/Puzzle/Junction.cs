using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Junction : MonoBehaviour
{
    [Header("Rotation Variables")]
    //[SerializeField] float turnTime = 1;
    [SerializeField]
    private float turnSpeed = 5;


    // bool triggerRotation;
    // Vector3 newRotation;
    // private bool IsTurning;

    private Quaternion targetRotation;

    [Header("Collider Variables")]
    public bool inputCollider;
    public bool outputCollider;


    [Header("Checking if energy can move")]
    public bool EnergyCanMove;
    public bool JunctionAligned;

    [Header("other scripts")]
    public GameObject Player;
    Interaction interaction;

    private void Awake()
    {
        targetRotation = transform.rotation;
        Player = GameObject.Find("PlayerManager/Player");
        interaction = Player.GetComponent<Interaction>();

    }
    private void Update()
    {
        //CheckForRotation();
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        CheckIfAligned();

    }
    public void CheckIfAligned()
    {
        //Via a puzzle check script check if the connected junction is aligned, then allow for energy to move.
            if (inputCollider && outputCollider)
            {
                //Debug.Log("lasering");
                Debug.Log("Junction Aligned: " + gameObject.name);
                //continue laser
                JunctionAligned = true;
               //JunctionsAligned += 1;
            }
            else
            {
                // Debug.Log("not lasering");
                Debug.Log("Junction NOT Aligned: " + gameObject.name);
                //stoplazer

                JunctionAligned = false;
            }


    }
    public void RotateJunction()
    {
        if (JunctionAligned == false)
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
