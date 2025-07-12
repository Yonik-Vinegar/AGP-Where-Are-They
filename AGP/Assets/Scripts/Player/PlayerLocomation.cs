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

    //private float playerHeight;
    //public GameObject Player;

    //[Header("Grounded Detection")]
    //public bool isGrounded;
    //private float groundDistance = 0.4f;
    //[SerializeField] LayerMask groundMask;
    //RaycastHit slopeHit;
    //Vector3 SlopeMoveDirection;



    public void Awake()
    {
        cameraObject =  Camera.main.transform;
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
        //playerHeight = Player.transform.localScale.y;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        
    }

    private void HandleMovement()
    {
        //if (isGrounded && !Onslope())
        //{
        //    moveDirection = cameraObject.forward * inputManager.verticalInput;
        //    moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        //    moveDirection.Normalize();
        //    moveDirection.y = -fallSpeed;
        //    moveDirection = moveDirection * movementSpeed;

        //    Vector3 movementVelocity = moveDirection;
        //    playerRigidBody.velocity = movementVelocity;
        //}
        //else if (isGrounded && Onslope())
        //{
        //    SlopeMoveDirection = cameraObject.forward * inputManager.verticalInput;
        //    SlopeMoveDirection = SlopeMoveDirection + cameraObject.right * inputManager.horizontalInput;
        //    SlopeMoveDirection.Normalize();
        //    SlopeMoveDirection.y = -fallSpeed;
        //    SlopeMoveDirection = SlopeMoveDirection * movementSpeed;

        //    Vector3 movementVelocity = SlopeMoveDirection;
        //    playerRigidBody.velocity = movementVelocity;
        //}
        //else if (!isGrounded)
        //{

        //}
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = -fallSpeed;
        moveDirection = moveDirection * movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidBody.velocity = movementVelocity;
    }

    //private void update()
    //{
    //    isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance, groundMask);

    //    SlopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    //}

    //private bool Onslope()
    //{
    //    if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
    //    {
    //       if (slopeHit.normal != Vector3.up)
    //       {
    //         return true;
    //       }
    //       else
    //       {
    //         return false;
    //       }
    //    }
    //    return false;
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
        fallSpeed = 0;
    }
}
