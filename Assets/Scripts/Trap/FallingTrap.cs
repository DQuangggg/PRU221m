using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : TrapBase
{
    Rigidbody2D rb;
    bool fall = false;
    public float gravity;
    public float mass;

    private void Awake()
    {
        character = FindObjectOfType<CharacterController>();
        audioManager = FindObjectOfType<AudioManager>();
        heartManager = FindObjectOfType<HeartManager>();
        gameOverScreen = FindObjectOfType<GameOverScript>();
        trapType = TrapType.Effect;
    }

    public override void getName()
    {
        Debug.Log("Falling trap");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        rb = GetComponent<Rigidbody2D>();
        if (!fall)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.isKinematic = false;
                rb.gravityScale = gravity;
                rb.mass = mass;
                fall = true;
                StartCoroutine(Disappear());
            }
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Trap")
        {
            gameObject.tag = "Trap";
        }
        if ( collision.gameObject.tag == "Player"
            && canAttack == true && character.isAllowInput)
        {
            attacked();
           
        }
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);

    }

    private void OnBecameInvisible()
    {
        if (isDelay)
        {
            if (heartManager.health > 0)
            {
                character.Teleport();

                isDelay = false;
                canAttack = true;
            }

        }
    }

  
}