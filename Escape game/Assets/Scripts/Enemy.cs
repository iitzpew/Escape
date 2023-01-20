using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float damageAmount = 5f;


    private float distance;

    void Start()
    {

    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 3)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("takedamage");
            TakeDamage(damageAmount);
        }
    }
}