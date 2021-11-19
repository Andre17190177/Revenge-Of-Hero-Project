using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaBar : MonoBehaviour
{
    private Manaa manaa;
    private Image mana;

    private void Awake()
    {
        mana = transform.Find("ManaBar").GetComponent<Image>();

        manaa = new Manaa();
    }

    private void Update()
    {
        manaa.Update();

        mana.fillAmount = manaa.GetManaNormalize();
    }
}

public class Manaa
{
    public const int MANA_MAX = 100;

    private float manaAmount;
    private float manaRegenAmount;

    public Manaa()
    {
        manaAmount = 0;
        manaRegenAmount = 30f;
    }

    public void Update()
    {
        manaAmount += manaRegenAmount * Time.deltaTime;
    }

    public void SpendMana(int amount)
    {
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }

    public float GetManaNormalize()
    {
        return manaAmount / MANA_MAX;
    }

}