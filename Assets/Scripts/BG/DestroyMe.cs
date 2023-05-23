using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    private float aliveTime = 0.5f;
    void Start()
    {
        Destroy(gameObject,aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
