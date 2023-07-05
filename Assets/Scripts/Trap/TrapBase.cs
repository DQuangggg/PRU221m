using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBase : MonoBehaviour
{
    // Start is called before the first frame update
    protected HeartManager heartManager;

    protected TrapType trapType;

    protected CharacterController character;
    protected AudioManager audioManager;
    protected GameOverScript gameOverScreen;
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
        Debug.Log("Name of trap: ");
    }
    public void attacked()
    {
        if (character != null && audioManager != null && heartManager != null)
        {
            getName();
            character.SetDead(true);
            Instantiate(character.getBlood(), character.transform.position, character.transform.rotation);
            audioManager.PlaySFX(audioManager.dead2);
            StartCoroutine(waiter());
        }
    }

    public void bossAttacked()
    {
        if (character != null && audioManager != null && heartManager != null)
        {
            Debug.Log("cham orif");
            getName();
            character.SetDead(true);
            character.SetBodyType(RigidbodyType2D.Static);
            audioManager.PlayMusicBackground(false);
            audioManager.PlaySFX(audioManager.gameover);
            GameOver();

            JsonHandler handler = gameObject.AddComponent<JsonHandler>();
            handler.data = new SavedPositionData();
            handler.Save();
        }
    }
    public IEnumerator waiter()
    {
        character.SetBodyType(RigidbodyType2D.Static);
       
        if (heartManager.health <= 0)
        {
            audioManager.PlayMusicBackground(false);
            audioManager.PlaySFX(audioManager.gameover);
            GameOver();

            JsonHandler handler = gameObject.AddComponent<JsonHandler>();
            handler.data = new SavedPositionData();
            handler.Save();
        }
        else
        {
            character.SetDead(false);
            CheckpointRespawn();
            character.SetBodyType(RigidbodyType2D.Dynamic);
        }
        yield return new WaitForSeconds(0.5f);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (trapType == TrapType.Effect) {
                attacked();
            }
            if (trapType == TrapType.Boss) {
                bossAttacked();
            }
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

    public void CheckpointRespawn()
    {
        //respawn
        character.transform.position = new Vector3(character.getCheckPointPassed().x, character.getCheckPointPassed().y, 0);
        //minus HP
        heartManager.MinusHeart();
    }
}


