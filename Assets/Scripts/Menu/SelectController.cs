using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectController : MonoBehaviour
{
    public Button level02Button, level03Button;
    int levelPassed;

    private void Start()
    {
       /* levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02Button.interactable = false;
        level03Button.interactable = false;

        switch(levelPassed)
        {
            case 1: 
                level02Button.interactable=true;
                break;
            case 2:
                level02Button.interactable=true;
                level03Button.interactable=true;
                break; 
        }
*/
    }

    public void levelToLoad(string level)
    {
        SceneManager.LoadScene(level);
    }

}
