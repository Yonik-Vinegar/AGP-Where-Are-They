using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    public GameObject SoundMenu;

    void Start()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Mainscene");
        Debug.Log("UI sucks");
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }



}
