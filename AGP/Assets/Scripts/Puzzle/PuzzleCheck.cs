using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck : MonoBehaviour
{
    public GameObject ConnectedJunction;
    [SerializeField] Junction JunctionScript;
    public bool EnergyCanProceed;
    //public GameObject Energy;
    //PuzzleFlow PuzzleFlow;
    // Start is called before the first frame update
    //bool[] JunctionsCompleted;
    private void Awake()
    {
        JunctionScript = ConnectedJunction.GetComponent<Junction>();
        //PuzzleFlow = Energy.GetComponent<PuzzleFlow>();
    }

   
    void Update()
    {
        if (JunctionScript.JunctionAligned == true)
        {
            Debug.Log("SettingAlignment");
            EnergyCanProceed = true;
            //PuzzleFlow.JunctionsAlignCheck;
        }
        else
        {
            EnergyCanProceed = false;
        }
    }
}   
