using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _newGameLevel, _newLevel;


    private void Start()
    {
        Time.timeScale = 1;
    }

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void NewLevel()
    {
        SceneManager.LoadScene(_newLevel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
