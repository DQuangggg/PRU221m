using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpike : MonoBehaviour
{
    [SerializeField]
    public float xDistanceToMainCharacter;
    [SerializeField]
    public float yDistanceToMainCharacter;
    [SerializeField]
    public float xMoveDistance;
    [SerializeField]
    public float yMoveDistance;

    public Vector3 destination;

    void Start()
    {
        destination = new Vector3(this.gameObject.transform.position.x + xMoveDistance, this.gameObject.transform.position.y + yMoveDistance);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //float dis = Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x);
        //float dis1 = Mathf.Abs(this.gameObject.transform.position.y - player.transform.position.y);
        //Debug.Log(dis +" and "+ dis1);

        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < xDistanceToMainCharacter ||
            Mathf.Abs(this.gameObject.transform.position.y - player.transform.position.y) < yDistanceToMainCharacter)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 2);
        }
    }
}
