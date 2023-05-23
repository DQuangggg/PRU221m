using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject object1;
    private Animator animator1;

    void Start()
    {
        animator1 = object1.GetComponent<Animator>();
        animator1.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            animator1.enabled = true;
        }
    }
}