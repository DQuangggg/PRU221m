using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBall : MonoBehaviour
{
    private bool isPush = false;
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isPush)
        {
            gameObject.tag = "CircleKillBoss";
            Vector2 movement = new Vector2(-1f, 0f);
            rb.velocity = movement * speed;
        }
        else
        {
            gameObject.tag = "Untagged";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PushGround"))
        {
            isPush = true;
        }
    }
}
