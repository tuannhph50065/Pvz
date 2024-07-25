using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public Transform[] SpawnPoint;

    public GameObject zombie;

    private void Start()
    {
        InvokeRepeating("SpawnZombie", 2, 5);
    }

    void SpawnZombie()
    {
        int r = Random.Range(0,SpawnPoint.Length);
        GameObject Myzombie = Instantiate(zombie, SpawnPoint[r].position, Quaternion.identity);  
    }
}
