using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    private float DropToyPos;

    private float speed = .5f;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(-4.5f, 8f), 6, 0);

        DropToyPos = Random.Range(2.5f, -3.9f);

        Destroy(gameObject, Random.Range(6, 12));
    }

    private void Update()
    {
        if (transform.position.y >= DropToyPos)
        transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
       
    }
}
