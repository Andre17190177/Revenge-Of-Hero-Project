using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 100f;
    public static float hp;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image> ();
        hp = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = hp / maxHealth;
    }
}
