using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public bool isActivated = false;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;
            gameObject.SetActive(true);
        }
    }
}
