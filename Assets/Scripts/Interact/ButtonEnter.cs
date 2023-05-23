using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnter : MonoBehaviour
{
    private bool standUp = false;
    private bool isStandUp;
    private Vector3 defaultValue;
    public GameObject pushingBall;
    private Vector3 defaultPushing;
    private void Start()
    {
        defaultPushing = pushingBall.transform.position;
        defaultValue = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 originalPosition = new Vector3(defaultValue.x, defaultValue.y - 0.3f, defaultValue.z);
        Vector3 newPostPushing = new Vector3(defaultPushing.x - 1.02f, defaultPushing.y, defaultPushing.z);
        if (isStandUp)
        {
            transform.position = originalPosition;
            pushingBall.transform.position = newPostPushing;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isStandUp = true;
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        isStandUp = false;
    //    }
    //}

    public void ButtonDown()
    {
        standUp = true;
    }
}
