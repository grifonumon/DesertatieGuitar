using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] posiblePositions; 
    // Start is called before the first frame update
    void Start()
    {
        Transform spawnPoint = posiblePositions[Random.Range(0, posiblePositions.Length)];
        this.gameObject.transform.position = spawnPoint.position;
    }

}
