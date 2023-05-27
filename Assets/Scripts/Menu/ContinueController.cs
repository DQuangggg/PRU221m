using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueController : MonoBehaviour
{
    public static int _lastSceneIndex;

    public void loadSceneByIndex(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
    void Awake()
    {
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
