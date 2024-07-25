using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    private float DropToyPos;

    private float speed = .5f;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(1.5f, 15f), 12.5f, 0);

        DropToyPos = Random.Range(9f, 1f);

        Destroy(gameObject, Random.Range(6, 12));
    }

    private void Update()
    {
        if (transform.position.y >= DropToyPos)
        transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
       
    }
}
