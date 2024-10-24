using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    public Transform targetTransform; //The object the camera will follow 
    public Transform cameraTransform; //The transform of the actaul camera object in the scene - error had to change to public

    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;

    public float lookAngleY; // Camera looking up and down
    public float lookAngleX; // Camera looking left and right
    public float minimumPivotAngle = -35;
    public float maximumPivotAngle = 35;

    public void Awake()
    {

        inputManager = GetComponent<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
    }

    //public void HandleCameraRotaion()
    //{
    //    RotateCamera();
    //}
    public void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;


        lookAngleY = lookAngleY + (inputManager.cameraInputX * cameraLookSpeed);
        lookAngleX = lookAngleX - (inputManager.cameraInputY * cameraPivotSpeed);
        lookAngleX = Mathf.Clamp(lookAngleX, minimumPivotAngle, maximumPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngleY;
        targetRotation = Quaternion.Euler(rotation); // because we put Quaternion targetRotation ealier it means we don't have to put Quaternion now
        transform.localRotation = targetRotation;  //learning jrl used target transform instead of transform making it change the capsule direction. But since this is linked to the camera it has no effect

        rotation = Vector3.zero;
        rotation.x = lookAngleX;
        targetRotation = Quaternion.Euler(rotation);
        transform.localRotation = targetRotation; //Local rotation = the game object rotation not the world
    }
}
