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
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    public GameObject BloodEffect;
    float horizontalMove;
    bool facingRight;
    bool grounded;
    Animator animator;
    Rigidbody2D rb;

    public AudioSource audioSource;
    [Header("SoundFX")]
    [SerializeField]
    public AudioClip jumpClip;
    [SerializeField]
    public AudioClip deathClip;
    [SerializeField]
    public AudioClip gameOverClip;
    [SerializeField]
    public AudioSource backGroundClip;

    SpawPoint spawPoint;
    SpawPoint spawPoint1;

    public int hearts = 5;

    public GameObject pauseMenuScreen;
    public GameObject gameOverScreen;
    AudioManager audioManager;

    public HeartManager heartManager;
    public Vector3 checkPointPassed;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;
        audioSource = gameObject.GetComponent<AudioSource>();
        backGroundClip.Play();
        spawPoint = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<SpawPoint>();
        spawPoint1 = GameObject.FindGameObjectWithTag("SpawnPoint1").GetComponent<SpawPoint>();
        Time.timeScale = 1;

        heartManager = gameObject.GetComponent<HeartManager>();
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);


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
                //audioSource.PlayOneShot(jumpClip);
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
        if (collision.gameObject.tag == "Trap")
        {
            animator.SetBool("dead", true);
            Instantiate(BloodEffect, transform.position, transform.rotation);
            //audioSource.PlayOneShot(deathClip);
            audioManager.PlaySFX(audioManager.dead2);
            StartCoroutine(waiter());
        }
        if (collision.gameObject.tag == "Boos") {
            backGroundClip.Stop();
            audioManager.PlaySFX(audioManager.gameover);
            GameOver();
        }

        IEnumerator waiter()
        {
            //stop all movement on main character
            rb.bodyType = RigidbodyType2D.Static;
            yield return new WaitForSeconds(0.5f);
            if (heartManager.health <= 0)
            {
                backGroundClip.Stop();
                audioManager.PlaySFX(audioManager.gameover);
                GameOver();
            }
            else
            {
                animator.SetBool("dead", false);
                CheckpointRespawn();
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }

    }

    void CheckpointRespawn()
    {
        //respawn
        transform.position = new Vector3(checkPointPassed.x, checkPointPassed.y, 0);
        //minus HP
        heartManager.MinusHeart();
    }

    public void nextLevel()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 4)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadSceneAsync(++currentScene);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        JsonHandler handler = gameObject.AddComponent<JsonHandler>();
        handler.data = new SavedPositionData();
        handler.Save();
        SceneManager.LoadScene("MainMenu");
    }

    public void replay()
    {
        JsonHandler handler = gameObject.AddComponent<JsonHandler>();
        handler.data = new SavedPositionData();
        handler.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
