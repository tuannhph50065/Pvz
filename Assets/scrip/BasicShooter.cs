using System.Collections;
using UnityEngine;

public class Peashooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Prefab của đạn
    [SerializeField] private float shootingInterval = 2f; // Khoảng thời gian giữa các lần bắn
    [SerializeField] private Transform shootingPoint; // Điểm xuất phát của đạn
    [SerializeField] private float maxDetectionDistance = 10f; // Khoảng cách tối đa để phát hiện zombie
    [SerializeField] private LayerMask zombieLayer; // Layer của zombie

    private void Start()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingInterval);

            if (DetectZombie(out Vector2 targetPosition))
            {
                ShootBullet(targetPosition);
            }
        }
    }

    private bool DetectZombie(out Vector2 targetPosition)
    {
        targetPosition = Vector2.zero;

        // Phát tia từ vị trí của Peashooter về phía trước (hoặc hướng bắn của Peashooter)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, maxDetectionDistance, zombieLayer);

        if (hit.collider != null)
        {
            targetPosition = hit.collider.transform.position;
            return true;
        }
        return false;
    }

    private void ShootBullet(Vector2 targetPosition)
    {
        if (bulletPrefab != null && shootingPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                Vector2 direction = (targetPosition - (Vector2)shootingPoint.position).normalized;
                bulletScript.SetDirection(direction);
            }
            else
            {
                Debug.LogWarning("Bullet script is missing on the bullet prefab.");
            }
        }
        else
        {
            Debug.LogWarning("Bullet prefab or shooting point not assigned.");
        }
    }
}
