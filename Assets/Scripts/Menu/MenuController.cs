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

    public void loadSceneByName(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    public void ContinueButtonClick()
    {
        try
        {
            //load file
            JsonHandler handler = gameObject.AddComponent<JsonHandler>();
            handler.Load();
            //if there's no data -> go to Scene 1
            if (handler.data.sceneName == "")
            {
                throw new Exception();
            }
            //go to scene
            loadSceneByName(handler.data.sceneName);
        }
        catch (Exception)
        {
            //if can't find file -> go to Scene 1 (default)
            loadSceneByName("Scene1");
        }
    }
}
