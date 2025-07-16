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
    public float fallSpeed;
    private bool Maybe;
    public float UpSpeed;




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
        moveDirection.y = -fallSpeed;
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidBody.velocity = movementVelocity;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slope"))
        {
            fallSpeed = 0.5f;
            movementSpeed = 7f;
            Maybe = true;
        }
        if (other.CompareTag("Upslope"))
        {
            if (Maybe == false)
            {
                fallSpeed = 0f;
                movementSpeed = UpSpeed;
            }
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Upslope"))
        {
            Maybe = false;
        }
    }


}
