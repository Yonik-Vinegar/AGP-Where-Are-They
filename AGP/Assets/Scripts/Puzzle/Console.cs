using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    [SerializeField] private MainJunctionScript previousJunction;
    public Material[] materials;
    Renderer rend;
    public Animator mAnimator;
    public bool CanActivate;


    [Header("For the final console")]
    public bool EndingTrigger;
    InputManager inputManager;
    public GameObject Player;
    public GameObject GameOverScreen;
    public GameObject BaseUI;
    public bool GameActive = true;

    [Header("Sound Effects for all consoles")]
    [SerializeField] private AudioClip EndSFX;
    [SerializeField] private AudioClip SFX;
    private AudioSource audioSource;
    public GameObject SFXObject;
    private bool SFXactivated;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        inputManager = Player.GetComponent<InputManager>();
        GameOverScreen.SetActive(false);
        audioSource = SFXObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (previousJunction.IsCharged)
        {
            rend.sharedMaterial = materials[1];
            CanActivate = true;
            if (SFXactivated == false)
            {
                audioSource.PlayOneShot(SFX);
                SFXactivated = true;
            }
            
            //put the SFX sound here for the computer charging up. The audio for doors opening will be put on the doors itself.
        }
        else
        {
            CanActivate = false;
        }

    }

    public void ConsoleTrigger()
    {
        if (mAnimator != null)
        {
            mAnimator.SetTrigger("DoorOpenTrigger");

        }
        EndGame();
    }

    public void EndGame()
    {
        if (EndingTrigger == true)
        {
            inputManager.lockCursor = false;
            inputManager.InteractionPerformed = false;
            GameOverScreen.SetActive(true);
            BaseUI.SetActive(false);
            Time.timeScale = 0;
            audioSource.PlayOneShot(EndSFX);
            GameActive = false;
        }
    }

}
