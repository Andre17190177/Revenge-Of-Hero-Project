using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public AudioClip deathClip;
    public GameObject enemy;
    public GameObject bloodEffect;
    public SpriteRenderer enemySprite;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource enemyAudio;
    public HealthBarBehaviour healthBar;

    bool isDead;
    bool damaged;

    // Start is called before the first frame update
    void Awake()
    {
        //Menapatkan reference komponen
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();

        currentHealth = startingHealth;

        //Set current health
        healthBar.SetHealth(currentHealth, startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Jika terkena damage
        if (damaged)
        {
            //Merubah warna gambar menjadi value dari flashColour
            enemySprite.color = flashColour;
        }
        else
        {
            //Fade out damage image
            enemySprite.color = Color.Lerp(enemySprite.color, Color.white, flashSpeed * Time.deltaTime);
        }

        //Set damage to false
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        //Check jika dead
        if (isDead)
            return;

        //play audio
        //enemyAudio.Play();

        anim.SetTrigger("isHurt");

        Instantiate(bloodEffect, transform.position, Quaternion.identity);

        //kurangi health
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth, startingHealth);

        //Dead jika health <= 0
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Debug.Log("Enemy Died");

        //set isdead
        isDead = true;

        //trigger play animation Dead
        anim.SetBool("isDead", true);

        //Play Sound Dead
        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        GetComponent<CircleCollider2D>().enabled = false;

        Invoke("DeactivateEnemy", 2f);
    }

    void DeactivateEnemy()
    {
        enemy.SetActive(false);
    }
}
