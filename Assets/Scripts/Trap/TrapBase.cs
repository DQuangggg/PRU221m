using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TrapBase : MonoBehaviour
{
    // Start is called before the first frame update
    protected HeartManager heartManager;

    protected TrapType trapType;

    protected CharacterController character;
    protected AudioManager audioManager;
    protected GameOverScript gameOverScreen;
    protected bool canAttack = true;
    protected bool isDelay = false;
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
            canAttack = false;
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
            getName();
            character.SetDead(true);
            Instantiate(character.getBlood(), character.transform.position, character.transform.rotation);
            audioManager.PlaySFX(audioManager.dead2);
            heartManager.health = 0;
            StartCoroutine(waiter());
        }
    }
    public IEnumerator waiter()
    {
        character.SetBodyType(RigidbodyType2D.Static);
        character.AllowInput(false);
        if (heartManager.health <= 0)
        {
            character.AllowInput(false);
            //yield return new WaitForSeconds(0.5f);
            gameOverScreen.Activate();
            character.SetBodyType(RigidbodyType2D.Static);

            character.SetBodyType(RigidbodyType2D.Dynamic);
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
            character.SetBodyType(RigidbodyType2D.Static);
            character.SetBodyType(RigidbodyType2D.Dynamic);
            CheckpointRespawn();
            canAttack = true;

        }
        yield return new WaitForSeconds(0f);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && canAttack)
        {
            if (trapType == TrapType.Effect)
            {
                attacked();
            }
            if (trapType == TrapType.Boss)
            {
                bossAttacked();
            }
        }
    }

    public void GameOver()
    {
        StartCoroutine(DisplayGameOverScreen());
    }

    public void CheckpointRespawn()
    {
        StartCoroutine(RespawnAfterDelay());
    }
    public IEnumerator RespawnAfterDelay()
    {
        Debug.Log("Enter to RespawnAfterDelay");
        if (!isDelay)
        {
            character.AllowInput(false);
            heartManager.MinusHeart();
            isDelay = true;
            //Chạy được đến đây
            character.Teleport();
             //character.tag = "Player";
             yield return new WaitForSeconds(0.5f);
            isDelay = false;
            // Respawn
            // Minus HP


        }
        else
        {
            canAttack = true;
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    // Kiểm tra nếu đối tượng va chạm không phải là Ground và không phải là đối tượng nhân vật người chơi
    //    if (other.gameObject.CompareTag("Ground") == false && other.gameObject != character.gameObject)
    //    {
    //        // Thực hiện hành động mà bạn mong muốn ở đây
    //        // Ví dụ: loại bỏ khả năng va chạm của đối tượng
    //        Physics.IgnoreCollision(other, GetComponent<Collider>());
    //    }
    //}
    private void OnBecameInvisible()
    {
        if (isDelay)
        {
            if (heartManager.health > 0)
            {
                character.Teleport();
                //yield return new WaitForSeconds(0.5f);
                isDelay = false;
                canAttack = true;
            }

        }
    }
    public IEnumerator DisplayGameOverScreen()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverScreen.Activate();
    }
}


