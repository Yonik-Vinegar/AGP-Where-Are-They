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

    [Header("Changing Materials")]
    public Material[] materials;
    public renderer PipesRenderer;
    public Gameobject[] Pipes;
    [Header("SFX")]
    private AudioSource audioSource;
    public GameObject SFXObject;
    [SerializeField] private AudioClip SFX;

    private void Awake()
    {
        targetRotation = transform.rotation;
        audioSource = SFXObject.GetComponent<AudioSource>();
        PipesRenderer = Pipes[].GetComponents<PipesRenderer>();
    }
    void Update()
    {
        CheckPreviousJunction();
        CheckTriggers();
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        if (IsCharged)
        {
            Renderer rend;

        }
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
    //Connor aided in the functions below.
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
            audioSource.PlayOneShot(SFX);
        }

    }
    public void Interact()
    {
        Debug.Log("interacting with junction");
        RotateJunction();
    }
}
