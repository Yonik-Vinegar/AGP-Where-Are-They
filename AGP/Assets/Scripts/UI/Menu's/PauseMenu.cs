using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject PMenu;
    [SerializeField] private GameObject HeartRateBackGrd;
    [SerializeField] private GameObject HeartRate;
    [SerializeField] private GameObject Crosshair;
    [Header("Input")]
    InputManager inputManager;
    public GameObject Player;
    public bool isPaused;
    public GameObject soundMenu;
    public GameObject SoundControls;
    public Button soundButton;
    SoundController soundController;


    // Start is called before the first frame update
    void Awake()
    {
        
    }


    void Start()
    {
        PMenu.SetActive(false);
        inputManager = Player.GetComponent<InputManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.PausePressed == true)
        {
            if (isPaused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void PauseGame()
    {
        PMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        inputManager.lockCursor = false;
        HeartRate.SetActive(false);
        Crosshair.SetActive(false);
        HeartRateBackGrd.SetActive(false);
    }

    public void ResumeGame()
    {
        PMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        HeartRate.SetActive(true);
        Crosshair.SetActive(true);
        inputManager.lockCursor = true;
        HeartRateBackGrd.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Sound()
    {
        soundMenu = FindObjectOfType<SoundController>().SoundMenu;
        soundMenu?.SetActive(true);
        PMenu.SetActive(false);
        SoundControls = FindObjectOfType<SoundController>().SoundManager;
        soundController = SoundControls.GetComponent<SoundController>();
        soundController.IsGameScene = true;
    }
}
