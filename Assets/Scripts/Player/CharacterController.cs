using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    public GameObject BloodEffect;
    float horizontalMove;
    bool facingRight;
    bool grounded;
    Animator animator;
    Rigidbody2D rb;

    public GameObject gameOverScreen;



    public int hearts = 5;

    AudioManager audioManager;

    private HeartManager heartManager;
    public Vector3 checkPointPassed;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
        else
        {
            Instance = new CharacterController();
        }
        audioManager = FindObjectOfType<AudioManager>();
    }
    public Transform getTranform()
    {
        return gameObject.transform;
    }
    public Object getBlood()
    {
        return BloodEffect;
    }

    public void SetBodyType(RigidbodyType2D type)
    {
        rb.bodyType = type;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        facingRight = true;

        audioManager.PlayMusicBackground(true);
        Time.timeScale = 1;

        heartManager = gameObject.GetComponent<HeartManager>();
    }
    public void SetDead(bool status)
    {
        animator = GetComponent<Animator>();
        animator.SetBool("dead", status);
    }
    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        //transform.position += new Vector3(horizontalMove * speed * Time.deltaTime, 0, 0);

        if (horizontalMove > 0 && !facingRight)
        {
            flip();
        }
        else if (horizontalMove < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded)
            {
                animator.SetBool("jump", true);
                grounded = false;
                audioManager.PlaySFX(audioManager.jump);
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Hazard")
        {
            grounded = true;

        }
    }
    public Vector3 getCheckPointPassed()
    {
        return checkPointPassed;
    }
}
