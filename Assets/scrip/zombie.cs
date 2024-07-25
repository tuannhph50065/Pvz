using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public float Speed;
    public int Health;

    private void FixedUpdate()
    {
        // Di chuyển zombie sang trái dựa trên tốc độ Speed
        transform.position -= new Vector3(Speed * Time.fixedDeltaTime, 0, 0);
    }

    public void Hit(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject); // Hủy đối tượng zombie nếu hết máu
            Debug.Log("dd");
        }
    }
}
