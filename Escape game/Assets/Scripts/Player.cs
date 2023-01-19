using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private float jumpHeight = 10;
    public bool isJumping = false;
    private Rigidbody2D m_Rigidbody2D;


    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        m_Rigidbody2D.velocity = new Vector2(5 * moveX, m_Rigidbody2D.velocity.y);


        {
            if (Input.GetKeyDown("space") && isJumping == false)
            {
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpHeight);
                isJumping = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }
}