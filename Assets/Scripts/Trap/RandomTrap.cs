using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrap : MonoBehaviour
{
    public GameObject trapPrefab;
    public Transform[] trapPositions;


    void Start()
    {
        int randomIndex = Random.Range(0, trapPositions.Length);
        Vector3 trapPosition = trapPositions[randomIndex].position;
        Instantiate(trapPrefab, trapPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
