using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    protected Animator Animator; // Đổi tên trường này để tránh xung đột
    protected SpriteRenderer spriteRenderer;
    protected bool canMove = false;
    protected bool checkCollision = false;

    protected void Start()
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        if (canMove == true)
        {
            Move(speed);
        }
    }

    protected void StartMove()
    {
        canMove = true;
    }

    protected void StopMove()
    {
        canMove = false;
    }

    protected void Move(float x)
    {
        transform.Translate(Vector2.left * x * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant")) // Đảm bảo tag là "Plant"
        {
            checkCollision = true;
            StopMove(); // Dừng chuyển động tạm thời khi va chạm với plant
            Debug.Log("đã dừng");
        }
        else
        {
            checkCollision = false;
            StartMove();
            Debug.Log("di chuyển");
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(FlashFx());

        if(health <= 0)
            Destroy(gameObject);
    }

    private IEnumerator FlashFx()
    {
        spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(1f, 1f, 1f);
    }
}
