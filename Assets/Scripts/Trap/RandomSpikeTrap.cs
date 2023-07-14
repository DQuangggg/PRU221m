using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Trap
{
    public class RandomSpikeTrap : Trap
    {
        public GameObject _trapPrefab;
        public Transform[] trapPositions;

        public override void Activate(TrapType type)
        {

            trapType = type;
            int randomIndex = Random.Range(0, trapPositions.Length);
            Vector3 trapPosition = trapPositions[randomIndex].position;
            Instantiate(_trapPrefab, trapPosition, Quaternion.identity);
        }
    }
}
