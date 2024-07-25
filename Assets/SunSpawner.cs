using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    public GameObject SunObject;
    private void Start()
    {
        SpawnSun();
    }

    void SpawnSun()
    {
        Instantiate(SunObject);
        Invoke("SpawnSun", Random.Range(4, 10));
    }
}
