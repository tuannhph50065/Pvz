using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public float Speed;

    public int Heath;

    private void FixedUpdate()
    {
        transform.position -= new Vector3(Speed, 0, 0);
    }

}
