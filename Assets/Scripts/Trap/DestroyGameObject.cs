using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrouGameObject : MonoBehaviour
{
    public float aliveTime;
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
