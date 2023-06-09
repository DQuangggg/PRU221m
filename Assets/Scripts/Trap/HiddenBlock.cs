using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBlock : TrapBase
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        trapType = TrapType.NoEffect;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
        }
    }

}
