using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject GamePauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Continue()
    {
        GamePauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        GamePauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void BackToTitleScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title_Screen");
    }

    public void BackToDesktop()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    
}