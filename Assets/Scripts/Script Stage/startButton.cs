using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public string ID;
    private Scene stage;
        
    public void loadStage()
    {
        SceneManager.LoadSceneAsync(ID);
        Time.timeScale = 1f;
    }

}