using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    [SerializeField] private MainJunctionScript previousJunction;
    public Material[] materials;
    Renderer rend;
    public Animator mAnimator;
    public bool CanActivate;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        //mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (previousJunction.IsCharged)
        {
            rend.sharedMaterial = materials[1];
            CanActivate = true;   
        }
        else
        {
            CanActivate = false;
        }
    }

    public void ConsoleTrigger()
    {
        if (mAnimator != null)
        {
            mAnimator.SetTrigger("DoorOpenTrigger");

        }
    }
}
