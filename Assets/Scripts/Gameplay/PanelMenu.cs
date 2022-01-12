using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject HUD;
    public AudioSource BGM;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamePaused()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        BGM.mute = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        BGM.mute = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void SelectStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Stage Selection");
    }

    public void NextStage()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
