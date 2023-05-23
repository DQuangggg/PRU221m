using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public Transform point1, point2;
    private Transform pointTarget;
    public float speed;
    void Start()
    {
        pointTarget = point1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointTarget.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, point1.position) <= 0f)
        {
            pointTarget = point2;
        }
        if (Vector2.Distance(transform.position, point2.position) <= 0f)
        {
            pointTarget = point1;
        }
    }
}
