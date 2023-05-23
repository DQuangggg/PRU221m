using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 0.1f;
    private float destroyDelay = 1f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
    //new Rigidbody2D rb;
    //bool fly = false;
    //public float gravity;

    //private GameObject moveBlockPrefab;
    //private Vector3 blockPosition;

    //void Start()
    //{
    //    blockPosition = transform.position;
    //    moveBlockPrefab = (GameObject)Resources.Load(@"Prefabs\FallingGround");
    //}

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    if (!fly)
    //    {
    //        if (collision.gameObject.tag == "Player")
    //        {
    //            rb.isKinematic = false;
    //            rb.gravityScale = gravity;
    //            fly = true;
    //        }
    //    }
    //    else
    //    {
    //        if (collision.gameObject.tag == "Trap")
    //        {
    //            gameObject.SetActive(false);
    //            Invoke("LoadResource", 2f);
    //        }
    //    }
    //}

    //void LoadResource()
    //{
    //    GameObject newObject = Instantiate(moveBlockPrefab, blockPosition, Quaternion.identity);
    //    Destroy(gameObject);
    //    newObject.SetActive(true);
    //}
}
