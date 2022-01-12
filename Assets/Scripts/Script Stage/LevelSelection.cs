using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    private static bool unlocked;
    public Image unlockImage;


    private void Start()
    {
        
    }

    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    private void UpdateLevelStatus()
    {
        int previousLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum.ToString()) > 0)
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
        }
    }
}