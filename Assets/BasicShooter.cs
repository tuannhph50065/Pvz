using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject bullet;

    public Transform shootOrigin;

    public float cooldown;

    private bool canShoot;

    public float range;

    public LayerMask ShootMask;

    private GameObject Target;

    private void Start()
    {
        Invoke("resetCooldown", cooldown);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, ShootMask);

        if (hit.collider)
        {
            Target = hit.collider.gameObject;

            shoot();
        }
    }

    void resetCooldown()
    {
        canShoot = true;
    }

    void shoot()
    {
        if (!canShoot)
            return;

        canShoot = false;

        Invoke("resetCooldown", cooldown);

        GameObject MyBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);

        
    }

}
