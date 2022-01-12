using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider enemySlider;
   // public Color low;
   // public Color high;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        enemySlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        enemySlider.gameObject.SetActive(health < maxHealth);
        enemySlider.value = health;
        enemySlider.maxValue = maxHealth;

        //enemySlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, enemySlider.normalizedValue);
    }
}
