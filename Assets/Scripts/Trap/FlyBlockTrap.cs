using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBlockTrap : TrapBase
{
    Rigidbody2D rb;
    bool fly = false;
    public float gravity;

    private GameObject flyBlockPrefab;
    private Vector3 blockPosition;


    void Start()
    {
        trapType = TrapType.NoEffect;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        rb = GetComponent<Rigidbody2D>();
        if (!fly)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.isKinematic = false;
                rb.gravityScale = gravity;
                fly = true;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Trap")
            {
                Destroy(gameObject);
            }
        }
    }
}

