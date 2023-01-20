using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public int damageAmount = 10;
    public int deathdamageAmount = 100;
    public GameObject Player;
    public Transform respawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public RectTransform healthbar;
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            //Player.transform.position = respawnPoint.position;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            TakeDamage(deathdamageAmount);
            Player.transform.position = respawnPoint.position;
        }
            
        healthbar.localScale = new Vector3(currentHealth / 100, 1, 1);
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(damageAmount);
        }
    }
}