using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Jobs;
using UnityEngine.Rendering;

public class PlayerLocomation : MonoBehaviour
{
    InputManager inputManager;
    Transform cameraObject;
    public float movementSpeed = 7f;
    Vector3 moveDirection;
    Rigidbody playerRigidBody;
    public float rotationSpeed = 15;
    public float fallSpeed =0.4f;

    //[Header("Slope Handling")]
    //public float maxSlopeAngle;
    //private RaycastHit slopeHit;
    //public float playerHeight;


    public void Awake()
    {
        cameraObject =  Camera.main.transform;
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = - fallSpeed;
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidBody.velocity = movementVelocity;

        // handling slope
        //if (Onslope())
        //{
        //    playerRigidBody.AddForce(GetSlopeMoveDirection() * movementSpeed * 20f, ForceMode.Force);
        //}
    }

    //private bool Onslope()
    //{
    //    if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f ))
    //    {
    //        float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
    //        return angle < maxSlopeAngle && angle != 0;
    //        Debug.Log("onslope");
    //    }

    //    return false;
    //}

    //private Vector3 GetSlopeMoveDirection()
    //{
    //    return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slope"))
        {
            fallSpeed = 0.1f;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        fallSpeed = 0.6f;
    }
}
