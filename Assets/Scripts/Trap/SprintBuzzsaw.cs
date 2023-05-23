using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintBuzzsaw : MonoBehaviour
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
        transform.RotateAround(transform.position, new Vector3(0, 0, 1), 200 * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, pointTarget.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, point1.position) <= 0f)
        {
            pointTarget = point2;
        }
        if (Vector2.Distance(transform.position, point2.position) <= 0)
        {
            pointTarget = point1;
        }
    }
}
