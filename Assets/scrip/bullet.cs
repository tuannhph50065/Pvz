using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public GameObject hitEffectPrefab; // Prefab cho hiệu ứng va chạm
    private Vector2 direction;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    private void Update()
    {
        // Di chuyển viên đạn theo hướng đã thiết lập
        transform.Translate(direction * speed * Time.deltaTime);

        // Kiểm tra nếu viên đạn ra ngoài màn hình, thì hủy
        if (transform.position.x > 20f) // Thay đổi giá trị này tùy theo kích thước màn hình của bạn
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra va chạm với đối tượng có tag là "Zombie"
        if (other.CompareTag("enemy"))
        {
            // Gọi phương thức Hit trên zombie và truyền sát thương
            Zombie zombie = other.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.Hit(damage);
            }

            // Tạo hiệu ứng va chạm nếu prefab được chỉ định
            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            }

            // Hủy viên đạn sau khi va chạm
            Destroy(gameObject);
        }
    }
}
