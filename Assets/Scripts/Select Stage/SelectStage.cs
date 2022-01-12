using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneManager.LoadSceneAsync("Main Menu");
            }
        }
    }

    public void BackButton()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
