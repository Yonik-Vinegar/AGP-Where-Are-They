using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    [SerializeField] private MainJunctionScript previousJunction;
    public Material[] materials;
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
    }

    private void Update()
    {
        if (previousJunction.IsCharged)
        {
            rend.sharedMaterial = materials[1];
        }
    }
}
