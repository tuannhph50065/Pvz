using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 5f;
    public int health = 100;
    public GameObject deathEffectPrefab; // Prefab cho hiệu ứng chết
    public AudioClip deathSound; // Âm thanh khi chết
    public AudioSource audioSource; // AudioSource để phát âm thanh

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (rb2d == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this GameObject.");
        }

        // Nếu không có AudioSource, thêm một AudioSource vào GameObject
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void FixedUpdate()
    {
        if (rb2d != null)
        {
            // Di chuyển zombie sang trái với tốc độ speed
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
    }

    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Tạo hiệu ứng chết nếu prefab được chỉ định
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // Phát âm thanh chết nếu clip âm thanh được chỉ định
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        Destroy(gameObject); // Hủy đối tượng zombie
        Debug.Log("Zombie died.");
    }
}
