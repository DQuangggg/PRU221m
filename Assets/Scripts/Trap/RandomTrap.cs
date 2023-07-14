using Assets.Scripts.Trap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrap : MonoBehaviour
{
    public GameObject trapPrefab;
    public Transform[] trapPositions;
    private TrapFactory trapFactory;

    void Start()
    {
        trapFactory = new TrapFactory();
        CreateTrapNew();
    }

    private void CreateTrapNew()
    {
        Trap trap = trapFactory.CreateTrap();
        RandomSpikeTrap randomTrap = (RandomSpikeTrap)trap;
        randomTrap._trapPrefab = trapPrefab;
        randomTrap.trapPositions = trapPositions;
        randomTrap.Activate(TrapType.Effect); 
    }
}
