using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBase : MonoBehaviour
{
    // Start is called before the first frame update
    private HeartManager heartManager;

    protected TrapType trapType;

    private CharacterController character;
    private AudioManager audioManager;
    private GameOverScript gameOverScreen;
    private void Awake()
    {
        character = FindObjectOfType<CharacterController>();
        audioManager = FindObjectOfType<AudioManager>();
        heartManager = FindObjectOfType<HeartManager>();
        gameOverScreen = FindObjectOfType<GameOverScript>();
    }
    //In ra tên của loại trap để debug
    public virtual void getName()
    {
        Debug.Log("TrapBase");
    }
    void attacked()
    {
        character.SetDead(true);
        Instantiate(character.getBlood(), character.transform.position, character.transform.rotation);
        audioManager.PlaySFX(audioManager.dead2);
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        character.SetBodyType(RigidbodyType2D.Static);
        yield return new WaitForSeconds(0.5f);
        if (heartManager.health <= 0)
        {
            audioManager.PlayMusicBackground(false);
            audioManager.PlaySFX(audioManager.gameover);
            GameOver();
        }
        else
        {
            character.SetDead(false);
            CheckpointRespawn();
            character.SetBodyType(RigidbodyType2D.Dynamic);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            attacked();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        if (gameOverScreen != null && !gameOverScreen.isActivated)
        {
            gameOverScreen.Activate();
        }
    }

    void CheckpointRespawn()
    {
        //respawn
        character.transform.position = new Vector3(character.getCheckPointPassed().x, character.getCheckPointPassed().y, 0);
        //minus HP
        heartManager.MinusHeart();
    }
}
