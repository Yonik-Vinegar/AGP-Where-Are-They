using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    private enum MusicIndexEnum
    {
        Normal,
        AllIn,
        ClosingIn,
        Menu,
        Sad,
        Tension
    }
    
    [SerializeField] private MusicIndexEnum musicIndex;
    [SerializeField] private float volumeMultiplier = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckTypeMusic();
        }
    }

    private void CheckTypeMusic()
    {
        MusicOrganiser.Instance.PlayMusic((int)musicIndex,1);
    }
    
    
}
