using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectZone : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.GetComponent<BossController>().SetFollow();
            boss.SetActive(true);
        }
    }
}
