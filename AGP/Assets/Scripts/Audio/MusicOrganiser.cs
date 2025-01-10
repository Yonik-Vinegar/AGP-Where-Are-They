using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOrganiser : MonoBehaviour
{
    [SerializeField] private AudioSource[] MusicObjects;
    private AudioSource CurrentMusic;
    [SerializeField] float startingMusicVolume = .2f;
    float desiredMusicVolume = .2f;
    [SerializeField] float musicMuteSpeed = 1;
    
    public static MusicOrganiser Instance;
    
    private void Awake()
    {
        CreateInstance();
        PlayMusic(0,1);
        HandleMusic(1);
    }

    private void Update()
    {
        HandleMusic(Time.unscaledDeltaTime*musicMuteSpeed);
    }

    private void CreateInstance()

    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void HandleMusic(float volumeChange)
    {
        foreach (AudioSource musicObject in MusicObjects)
        {
            if (musicObject != CurrentMusic)
            {
                musicObject.volume = musicObject.volume <= 0 ? 0 : musicObject.volume-volumeChange;
            }
            else
            {
                musicObject.volume = musicObject.volume >= desiredMusicVolume ? desiredMusicVolume : musicObject.volume+volumeChange;
            }
            
        }
    }

    public void PlayMusic(int musicIndex, float volumeMultiplier) //volume mult default is 1
    {
        CurrentMusic = MusicObjects[musicIndex];
        desiredMusicVolume = startingMusicVolume * volumeMultiplier;
    }
}
