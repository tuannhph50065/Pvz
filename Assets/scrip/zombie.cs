using System.Collections;
using UnityEngine;

public class Zombie : ZombieBase
{
    [SerializeField] private AudioClip hitByBullet;
    [SerializeField] private float shootingInterval = 2f; // Đổi tên biến cho chính xác hơn
    private AudioSource audioSource;


    void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        StartMove();
    }

    void Update()
    {
        base.Update();
        if(health <= 0)
        {
            GamePlay.instance.deadZombies++;
            Destroy(gameObject);
        }
        
        if(checkCollision == true)
        {
            Animator.SetBool("checkatk", true);
        }
        else
        {
            Animator.SetBool("checkatk", false);
        }
    }

    private void atk()
    {

    }

}
