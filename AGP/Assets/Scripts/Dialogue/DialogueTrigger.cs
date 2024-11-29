using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("VisualCue")]
    [SerializeField] private GameObject visualCue;

    

    private void Awake()
    {
        visualCue.SetActive(false);
    }
}
