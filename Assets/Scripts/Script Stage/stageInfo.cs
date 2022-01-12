using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageInfo : MonoBehaviour
{
    public Text stageNumber;

    public string ID;

    public startButton Startbutton;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void setID()
    {
        Startbutton.ID = ID;
    }

    public void oneOne()
    {
        stageNumber.text = "Stage 1.1";
    }

    public void oneTwo()
    {
        stageNumber.text = "Stage 1.2";
    }

    public void oneThree()
    {
        stageNumber.text = "Stage 1.3";
    }

    public void oneFour()
    {
        stageNumber.text = "Stage 1.4";
    }

    public void jungleBoss()
    {
        stageNumber.text = "Jungle Boss";
    }

    public void twoOne()
    {
        stageNumber.text = "Stage 2.1";
    }

    public void twoTwo()
    {
        stageNumber.text = "Stage 2.2";
    }

    public void twoThree()
    {
        stageNumber.text = "Stage 2.3";
    }

    public void twoFour()
    {
        stageNumber.text = "Stage 2.4";
    }

    public void villageBoss()
    {
        stageNumber.text = "Village Boss";
    }

    public void threeOne()
    {
        stageNumber.text = "Stage 3.1";
    }

    public void threeTwo()
    {
        stageNumber.text = "Stage 3.2";
    }

    public void threeThree()
    {
        stageNumber.text = "Stage 3.3";
    }

    public void threeFour()
    {
        stageNumber.text = "Stage 3.4";
    }

    public void empireBoss()
    {
        stageNumber.text = "Empire Boss";
    }

    public void Endless()
    {
        stageNumber.text = "Endless Mode";
    }
}
