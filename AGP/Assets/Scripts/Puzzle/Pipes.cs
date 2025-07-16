using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public Material[] materials;
    Renderer rend;
    public GameObject JunctionConnection;
    MainJunctionScript junctionScript;
    public bool FirstPipes;
    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        junctionScript = JunctionConnection.GetComponent<MainJunctionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstPipes == false)
        {
            if (junctionScript.IsCharged == true)
            {
                rend.sharedMaterial = materials[1];
            }
            else
            {
                rend.sharedMaterial = materials[0];
            }
        }
        else
        {
            rend.sharedMaterial = materials[1];
        }
    }
}
