using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1.5f;
    public int attackDamage = 10;

    private EnemyPatrol enemyPatrol;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    Animator anim;
    bool playerInRange;
    float timer;

    void Awake()
    {
        //Mencari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        //mendapatkan komponen player health
        playerHealth = player.GetComponent<PlayerHealth>();

        //mendapatkan komponen Animator
        anim = GetComponent<Animator>();

        //anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();

        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //Set player in range
        if (other.gameObject == player)
        {
            playerInRange = true;
            anim.SetBool("isAttacking", true);
        }
    }

    //Callback jika ada object yang keluar dari trigger
    void OnTriggerExit2D(Collider2D other)
    {
        //Set player not in range
        if (other.gameObject == player)
        {
            playerInRange = false;
            anim.SetBool("isAttacking", false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !playerInRange;

        //mentrigger animasi PlayerDead jika darah player kurang dari sama dengan 0
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void Attack()
    {
        //Reset timer
        timer = 0f;

        //Taking Damage
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage - playerHealth.currentDefense);
        }
    }
}
