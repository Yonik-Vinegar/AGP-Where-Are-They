using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Junction : MonoBehaviour
{
    [Header("Rotation Variables")]
    [SerializeField] float turnTime = 1;
    bool triggerRotation;
    Vector3 newRotation;

    [Header("Collider Variables")]
    public bool inputCollider;
    public bool outputCollider;


    private void Update()
    {
        CheckForRotation();
        CheckIfAligned();
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
            }
        }
    }

    public void CheckIfAligned()
    {
        if (inputCollider&&outputCollider)
        {
            Debug.Log("lasering");
            //continue laser
        }
        else
        {
            Debug.Log("not lasering");
            //stoplazer
        }
    }

    public void RotateJunction()
    {
        triggerRotation = true;
        newRotation = transform.rotation.eulerAngles;
        newRotation.z += 90;
    }
}
