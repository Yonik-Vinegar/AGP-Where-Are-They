using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public GameObject SoundMenu;


    void Awake()
    {
        DontDestroyOnLoad (this.gameObject);
        DontDestroyOnLoad(SoundMenu);
        SoundMenu.SetActive(false);
    }

    public void SetDialoguelvl(float lvl)
    {
        masterMixer.SetFloat("Dialogue", lvl);
    }

    public void SetSFXlvl(float lvl)
    {
        masterMixer.SetFloat("SFX", lvl);
    }    
    public void SetMusiclvl(float lvl)
    {
        masterMixer.SetFloat("Music", lvl);
    }

    public void SetMasterlvl(float lvl)
    {
        masterMixer.SetFloat("MasterVol", lvl);
    }

    public void ExitSound()
    {
        SoundMenu.SetActive(false);
    }

    public void Sound()
    {
        SoundMenu?.SetActive(true);
    }

}
