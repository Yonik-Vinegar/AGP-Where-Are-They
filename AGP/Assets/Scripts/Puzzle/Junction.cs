using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Junction : MonoBehaviour
{
    [Header("Rotation Variables")]
    [SerializeField] float turnTime = 1;
    bool triggerRotation;
    Vector3 newRotation;
    private bool IsTurning;


    [Header("Collider Variables")]
    public bool inputCollider;
    public bool outputCollider;


    [Header("Checking if energy can move")]
    public bool EnergyCanMove;
    public float JunctionsAligned;

    [Header("other scripts")]
    public GameObject Player;
    Interaction interaction;

    private void Awake()
    {
        Player = GameObject.Find("PlayerManager/Player");
        interaction = Player.GetComponent<Interaction>();

    }
    private void Update()
    {
        CheckForRotation();
        CheckIfAligned();

        if (interaction.PuzzleInteractionTriggered == true)
        {
            //check if it is rotating, then check if it is one of the possible positions.
            triggerRotation = true;
            if (IsTurning == false)
            {
                RotateJunction();
            }
        }
    }

    public void CheckForRotation()
    {
        if (triggerRotation)
        {
            Vector3 slerpedRotation = Vector3.Slerp(transform.rotation.eulerAngles, newRotation, turnTime * Time.deltaTime);
            transform.rotation = Quaternion.Euler(slerpedRotation);
            if (transform.rotation.eulerAngles == newRotation)
            {
                triggerRotation = false;
                IsTurning = false;
            }
            
        }
    }

    public void CheckIfAligned()
    {
        if (inputCollider && outputCollider)
        {
            Debug.Log("lasering");
            //continue laser
            EnergyCanMove = true;
            //JunctionsAligned += 1;
        }
        else
        {
            Debug.Log("not lasering");
            //stoplazer
            EnergyCanMove= false; 
        }
    }

    public void RotateJunction()
    {
        triggerRotation= true;
        newRotation = transform.rotation.eulerAngles;
        newRotation.z += 90;
        if (triggerRotation == true)
        {
            IsTurning = true;
        }

    }
    
}
