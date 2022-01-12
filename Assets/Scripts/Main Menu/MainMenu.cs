using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadSceneAsync("Prologue");
    }

    public void SelectStage()
    {
        SceneManager.LoadSceneAsync("Stage Selection");
    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +8);
    }

    public void BackMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
