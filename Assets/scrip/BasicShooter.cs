using System.Collections;
using UnityEngine;

public class Peashooter : PlantBase
{
    [Header("Bullet Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootingInterval = 2f;
    [SerializeField] private Transform shootingPoint;

    [Header("Raycast Info")]
    [SerializeField] private float DetectionDistance;
    [SerializeField] private LayerMask zombieLayer;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip idleSound;
    [SerializeField] private AudioClip shootSound;

    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, DetectionDistance, zombieLayer);
        if (hit.collider != null)
        {
            targetPosition = hit.collider.transform.position;
            return true;
        }
        else
        {
            targetPosition = Vector2.zero;
            return false;
        }
    }

    private void ShootBullet(Vector2 targetPosition)
    {
        if (bulletPrefab != null && shootingPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            bullet bulletScript = bullet.GetComponent<bullet>();
            if (bulletScript != null)
            {
                Vector2 direction = (targetPosition - (Vector2)shootingPoint.position).normalized;
                bulletScript.SetDirection(direction);
            }
            else
            {
                Debug.LogWarning("Bullet script is missing on the bullet prefab.");
            }

            if (shootSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
            else
            {
                Debug.LogWarning("AudioSource or shootSound is not assigned.");
            }
        }
        else
        {
            Debug.LogWarning("Bullet prefab or shooting point not assigned.");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + DetectionDistance, transform.position.y, 0));
    }

    // Hàm này sẽ được gọi bởi sự kiện animation
    public void OnShootEvent()
    {
        Debug.Log("Shoot event triggered!");
        // Gọi logic bắn đạn ở đây hoặc bất kỳ hành động nào bạn muốn thực hiện khi animation xảy ra
        if (bulletPrefab != null && shootingPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            bullet bulletScript = bullet.GetComponent<bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(Vector2.right);
            }
        }
    }
}
