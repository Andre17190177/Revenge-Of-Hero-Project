using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public Slider manaSlider;
    public Button skillButton;
    public int attackDamage = 15;
    public int currentDamage;
    public float attackRange = 0.5f;
    public int startingMana = 100;
    public float currentMana;
    public float manaReduce = 10f;
    public List<AudioClip> attackClip;
    public LayerMask enemyLayer;
    public float comboTolerance = 1f;

    private float comboTime;

    PlayerHealth playerHealth;
    AudioSource attackAudio;
    GameObject enemy;
    bool comboPossible;
    bool rage;
    int comboStep;

    private void Awake()
    {
        attackAudio = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        currentMana = startingMana;
        currentDamage = attackDamage;
        manaSlider.maxValue = startingMana;
        manaSlider.value = currentMana;
    }

    private void Update()
    {
        if (rage)
        {
            if(currentMana > 0)
            {
                currentMana = Mathf.Clamp((currentMana - manaReduce * Time.deltaTime), 0 , startingMana);
                manaSlider.value = currentMana;
                skillButton.interactable = false;
            }
        }

        if (currentMana <= 0)
        {
            rage = false;
            currentDamage = attackDamage;
            playerHealth.currentDefense = playerHealth.Defense;
            StartCoroutine(RegenMana());
        }

        if (comboTime > 0)
        {
            comboTime -= Time.deltaTime;
        }
        else
        {
            ComboReset();
        }
    }

    public void Attacking()
    {
        comboTime = comboTolerance;

        if (comboStep == 0)
        {
            animator.Play("Attack1");
            attackAudio.clip = attackClip[0];
            attackAudio.Play();
            comboStep = 1;
            return;
        }
        if (comboStep != 0)
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void Combo()
    {
        if(comboStep == 2)
        {
            animator.Play("Attack2");
            attackAudio.clip = attackClip[1];
            attackAudio.Play();
        }
        if (comboStep == 3)
        {
            animator.Play("Attack3");
            attackAudio.clip = attackClip[2];
            attackAudio.Play();
        }
    }

    public void ComboReset()
    {
        comboPossible = false;
        comboStep = 0;
    }

    public void GiveDamage()
    {
        Collider2D hitEnemies = Physics2D.OverlapCircle(attackPoint.position, attackRange, enemyLayer);

        if(hitEnemies != null)
        {
            hitEnemies.GetComponent<EnemyHealth>().TakeDamage(currentDamage);
        }
    }

    public void GiveDamageToBoss()
    {
        Collider2D hitEnemies = Physics2D.OverlapCircle(attackPoint.position, attackRange, enemyLayer);

        if (hitEnemies != null)
        {
            hitEnemies.GetComponent<BossHealth>().TakeDamage(currentDamage);
        }
    }

    public void Rage()
    {
        rage = true;

        currentDamage *= 2;
        playerHealth.currentDefense *= 2;
    }

    private IEnumerator RegenMana()
    {
        yield return new WaitForSeconds(2);

        while(currentMana <= 0)
        {
            currentMana = Mathf.Clamp((currentMana + 2 * Time.deltaTime), 0 , startingMana);
            manaSlider.value = currentMana;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
