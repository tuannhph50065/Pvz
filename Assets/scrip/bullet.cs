using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ZombieBase>() != null)
        {
            collision.GetComponent<ZombieBase>().TakeDamage(2);
        }


        if (collision.CompareTag("Zombies"))
        {
            Debug.Log("Va chạm: " + collision.name);
            Destroy(gameObject);
        }
    }
}
