using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public void nextLevel()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 4)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadSceneAsync(++currentScene);
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void replay()
    {
        JsonHandler handler = gameObject.AddComponent<JsonHandler>();
        handler.data = new SavedPositionData();
        handler.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
