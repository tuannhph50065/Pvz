using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public float speed;

    public int heath;

    private void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0 ,0);
    }
}
