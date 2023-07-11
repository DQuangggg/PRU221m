using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverScreenScript : MonoBehaviour
{
    public bool isActivated = false;

    private void Awake()
    {
        gameObject.SetActive(true);
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
