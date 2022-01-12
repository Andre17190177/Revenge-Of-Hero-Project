using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public Transform attackOffset;
    public float attackRange = 1f;
    public LayerMask playerLayer;

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

        enemyHealth = GetComponent<EnemyHealth>();
    }

    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //Set player in range
        if (other.gameObject == player)
        {
            playerInRange = true;
            anim.SetBool("Attack1", true);
        }
    }

    ////Callback jika ada object yang keluar dari trigger
    void OnTriggerExit2D(Collider2D other)
    {
        //Set player not in range
        if (other.gameObject == player)
        {
            playerInRange = false;
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
        }
    }

    void Update()
    {
        //mentrigger animasi PlayerDead jika darah player kurang dari sama dengan 0
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
            GetComponent<EnemyAI>().enabled = false;
        }
    }

    void Attack()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(attackOffset.position, attackRange, playerLayer);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage - playerHealth.currentDefense);
        }
    }
    private void OnDrawGizmosSelected()
	{
		if(attackOffset == null)
        {
            return;
        }

		Gizmos.DrawWireSphere(attackOffset.position, attackRange);
	}
}
