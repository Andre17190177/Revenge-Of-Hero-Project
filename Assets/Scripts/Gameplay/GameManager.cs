using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GameOver")]
    public GameObject gameOverPanel;
    public GameObject player;
    public PlayerHealth playerHealth;
    [SerializeField] EnemyAI enemyAI;
    public CameraMoveController cameraMove;
    public float fallPositionY;

    [Header("Stage Clear")]
    public GameObject stageClearPanel;
    public GameObject HUD;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.currentHealth <= 0 || player.transform.position.y < fallPositionY)
        {
            GameOver();
            enemyAI.enabled = false;
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        HUD.SetActive(false);
        cameraMove.enabled = false;
        playerHealth.currentHealth = 0;
        playerHealth.healthSlider.value = playerHealth.currentHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            stageClearPanel.SetActive(true);
            HUD.SetActive(false);
            animator.enabled = false;
        }
    }
}
