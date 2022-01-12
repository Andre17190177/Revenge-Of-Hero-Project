using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int Defense = 5;
    public int currentDefense;
    public Slider healthSlider;
    public Image damageImage;
    public List<AudioClip> playerClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;
    TouchControll touchControll;
    PlayerAttack playerAttack;
    bool isDead;
    bool damaged;
    bool rage;

    void Awake()
    {
        //Mendapatkan refernce komponen
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        touchControll = GetComponent<TouchControll>();
        playerAttack = GetComponentInChildren <PlayerAttack> ();
        currentHealth = startingHealth;
        currentDefense = Defense;
    }

    void Update()
    {
        //Jika terkena damage
        if (damaged)
        {
            //Merubah warna gambar menjadi value dari flashColour
            damageImage.color = flashColour;      
        }
        else
        {
            //Fade out damage image
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        //Set damage to false
        damaged = false;
    }

    //fungsi untuk mendapatkan damage
    public void TakeDamage(int amount)
    {
        damaged = true;

        //mengurangi health
        currentHealth = Mathf.Clamp(currentHealth - amount, 0 , startingHealth);

        //Merubah tampilan dari health slider
        healthSlider.value = currentHealth;

        //Memainkan suara ketika terkena damage
        playerAudio.clip = playerClip[1];
        playerAudio.Play();

        //Memanggil method Death() jika darahnya kurang dari sama dengan 10 dan belu mati
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void AddHealth(int health)
    {
        currentHealth = Mathf.Clamp(currentHealth + health, 0 , startingHealth);

        healthSlider.value = currentHealth;
    }

    public void Death()
    {
        isDead = true;

        //mentrigger animasi Die
        anim.SetBool("isDead", true);

        //Memainkan suara ketika mati
        playerAudio.clip = playerClip[0];
        playerAudio.Play();

        //mematikan script player movement
        touchControll.enabled = false;

        playerAttack.enabled = false;
    }

    public void RestartLevel()
    {
        //meload ulang scene dengan index 0 pada build setting
        SceneManager.LoadScene(0);
    }
}
