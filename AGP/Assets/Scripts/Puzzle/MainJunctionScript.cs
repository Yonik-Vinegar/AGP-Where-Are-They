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
    // Update is called once per frame
    void Update()
    {
        CheckPreviousJunction();
        CheckTriggers();
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
}
