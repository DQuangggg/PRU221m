using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public bool isActivated = false;
    [SerializeField] private GameObject wrapper;


    private void Awake()
    {
        wrapper.SetActive(isActivated);
    }

    public void Activate()
    {
        StartCoroutine(ShowGameOver());
    }

    private IEnumerator ShowGameOver()
    {
       yield return new WaitForSeconds(1f);
        isActivated = true;
        wrapper.SetActive(isActivated);
        Time.timeScale = 0;
    }
}
