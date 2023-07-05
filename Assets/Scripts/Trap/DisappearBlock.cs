using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearBlock : TrapBase
{
    void Start()
    {
        trapType = TrapType.NoEffect;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
}
