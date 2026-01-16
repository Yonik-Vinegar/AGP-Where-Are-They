using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightOff : MonoBehaviour
{
    public Animator lightAnim;
    
    public void TriggerOff()
    {
        lightAnim.SetBool("Off", true);
    }
    public void TriggerOn()
    {
        lightAnim.SetBool("Off", false);
    }
}
