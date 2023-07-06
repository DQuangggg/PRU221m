using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public delegate void HealthChangedDelegate(int newHealth);
    public event HealthChangedDelegate OnHealthChanged;

    public int maxHealth;
    public int numOfHearts;

    public GameObject[] heartss;

    public int health = 0;
    public string SceneName;

    void Start()
    {
        //Read data from File
        try
        {
            //load file
            JsonHandler handler = gameObject.GetComponent<JsonHandler>();
            handler.Load();

            //if data empty -> not
            if (handler.data.position.x == 0 && handler.data.position.y == 0)
            {
                throw new Exception();
            }
            //if level not correct -> not
            if (handler.data.sceneName != SceneName)
            {
                throw new Exception();
            }

            //Update Health
            health = handler.data.health;
            numOfHearts = health;
            ChangeHearts();
        }
        catch (Exception)
        {
            //Initiate default health if there's no previous data of health
            health = maxHealth;
            numOfHearts = maxHealth;
        }
    }
    public void ChangeHealth(int newHealth)
    {
        health = newHealth;
        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(health);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //image.sprite = hearts[characterController.hearts];
    }

    //Change the heart animation
    public void ChangeHearts()
    {
        for (int i = 0; i < heartss.Length; i++)
        {
            if (i < health)
            {
                heartss[i].GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                heartss[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    //minus health by 1
    public void MinusHeart()
    {
        health--;
        ChangeHearts();
    }

    public void Boss()
    {
        health = 0;
        ChangeHearts();
    }

    //restore full health
    public void RestoreHealth()
    {
        health = maxHealth;
        ChangeHearts();
    }
}