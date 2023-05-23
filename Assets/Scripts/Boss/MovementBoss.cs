using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoss : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform curentPoint;
    private bool allowFloow = false;
    public Transform target;
    public float speed;
    public float stopDistance = 2f;
    private bool isKilled;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        curentPoint = point2.transform;

    }
    void Update()
    {
        if (target.transform.position.y <= -8f)
        {
            //transform.LookAt(target);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            Vector2 point = curentPoint.position - transform.position;
            speed = 2f;
            if (curentPoint == point2.transform)
            {
                sr.flipX = true;
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                sr.flipX = false;
                rb.velocity = new Vector2(-speed, 0);
            }
            if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == point2.transform)
            {
                curentPoint = point1.transform;
            }
            if (Vector2.Distance(transform.position, curentPoint.position) < 0.5f && curentPoint == point1.transform)
            {
                curentPoint = point2.transform;
            }
        }
        if (isKilled)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CircleKillBoss"))
        {
            isKilled = true;
        }
        else
        {
            isKilled = false;
        }
    }

    public void SetFollow()
    {
        allowFloow = true;
    }
}
