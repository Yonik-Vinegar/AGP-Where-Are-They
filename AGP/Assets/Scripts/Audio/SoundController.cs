using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public GameObject SoundMenu;
    public GameObject PauseMenu;
    public GameObject SoundManager;
    public bool IsGameScene;


    public float Sensitivity = 1f;
    public Slider SensSlider;

    public static SoundController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad (this.gameObject);
        DontDestroyOnLoad(SoundMenu);
        SoundMenu.SetActive(false);
        CallSens();
    }

    public void CallSens()
    {
        Sensitivity = PlayerPrefs.GetFloat("Sensitivity", 1f);
        SensSlider.value = Sensitivity;
    }
    public void Update()
    {
        if (IsGameScene == true)
        {
            PauseMenu = FindObjectOfType<PauseMenu>().PMenu;
            Debug.Log("IsGameScene");
        }
        else
        {
            PauseMenu = null;
        }
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
        if (IsGameScene == true)
        {
            PauseMenu.SetActive(true);
        }
        SoundMenu.SetActive(false);
    }

    public void Sound()
    {

        SoundMenu?.SetActive(true);
    }


    public void AdjustSensitivity(float value)
    {
        Sensitivity = value;
        PlayerPrefs.SetFloat("Sensitivity", Sensitivity);
    }




}
