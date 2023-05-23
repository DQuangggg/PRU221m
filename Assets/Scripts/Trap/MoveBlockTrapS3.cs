using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockTrapS3 : MonoBehaviour
{
    new Rigidbody2D rb;
    bool fly = false;
    public float gravity;

    private GameObject move;
    private Vector3 movePosition;

    void Start()
    {
        movePosition = transform.position;
        move = (GameObject)Resources.Load(@"Prefabs\Fall2");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        rb = GetComponent<Rigidbody2D>();
        if (!fly)
        {
            if (collision.gameObject.tag == "Player")
            {
                rb.isKinematic = false;
                rb.gravityScale = gravity;
                fly = true;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Trap")
            {
                gameObject.SetActive(false);
                Invoke("LoadResource", 2f);
            }
        }
    }

    void LoadResource()
    {
        Destroy(gameObject);
        GameObject newObject = Instantiate(move, movePosition, Quaternion.identity);
        newObject.SetActive(true);
    }


}