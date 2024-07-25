using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage;

    public float speed = .8f;

    private void Update()
    {
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<zombie>(out zombie zombie))
        {
            zombie.Hit(damage);
            Destroy(gameObject);
        }
    }
}
