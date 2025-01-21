using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject PMenu;
    [SerializeField] private GameObject HeartRate;
    [SerializeField] private GameObject Crosshair;
    [Header("Input")]
    InputManager inputManager;
    public GameObject Player;
    public bool isPaused;

    // Start is called before the first frame update
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
    }

    public void ResumeGame()
    {
        PMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        HeartRate.SetActive(true);
        Crosshair.SetActive(true);
        inputManager.lockCursor = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
