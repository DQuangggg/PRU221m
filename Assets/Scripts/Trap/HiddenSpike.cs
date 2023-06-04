using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpike : TrapBase
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
        trapType = TrapType.Effect;
        destination = new Vector3(this.gameObject.transform.position.x + xMoveDistance, this.gameObject.transform.position.y + yMoveDistance);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //Trap position to Player position
        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < xDistanceToMainCharacter ||
            Mathf.Abs(this.gameObject.transform.position.y - player.transform.position.y) < yDistanceToMainCharacter)
        {
            //Position when Trap move
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 2);
        }
    }
}
