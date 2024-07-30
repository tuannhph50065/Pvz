using UnityEngine;

public class SunflowerController : MonoBehaviour
{
    public GameObject sunPrefab; // Prefab của mặt trời
    public float spawnInterval = 10f; // Thời gian giữa các lần tạo mặt trời
    public Transform sunSpawnPoint; // Điểm xuất phát của mặt trời (chân của Sunflower)

    private float timer = 0f;

    void Start()
    {
        if (sunPrefab == null || sunSpawnPoint == null)
        {
            Debug.LogError("SunPrefab or SunSpawnPoint is not assigned in the inspector.");
        }
    }

    void Update()
    {
        timer += Time.deltaTime; // Cập nhật timer

        if (timer >= spawnInterval)
        {
            SpawnSun();
            timer = 0f; // Reset timer
        }
    }

    void SpawnSun()
    {
        if (sunPrefab != null && sunSpawnPoint != null)
        {
            // Tạo một đối tượng mặt trời mới tại điểm xuất phát
            GameObject sun = Instantiate(sunPrefab, sunSpawnPoint.position, Quaternion.identity);

            // Nếu cần, bạn có thể điều chỉnh thêm để đảm bảo mặt trời không di chuyển
            Rigidbody2D rb = sun.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Dừng chuyển động của mặt trời nếu có Rigidbody2D
            }
        }
    }
}
