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
        isActivated = true;
        wrapper.SetActive(isActivated);
        Time.timeScale = 0;
    }
}
