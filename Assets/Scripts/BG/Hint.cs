using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    bool displayHint = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            displayHint = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            displayHint = false;
        }
    }

    void OnGUI()
    {
        if (displayHint)
        {
            GUI.Label(new Rect(2, 2, 500, 50), "HINT : Press E to teleport");
        }
    }


}
