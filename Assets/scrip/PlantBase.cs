using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBase : MonoBehaviour
{
    [SerializeField] protected float health;
    protected Animator animator;
    protected SpriteRenderer sr;


    protected void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
        StartCoroutine(FlashFx());
    }

    private IEnumerator FlashFx()
    {
        sr.color = new Color(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1f, 1f);
    }
    // Update is called once per frame
    protected void Update()
    {

    }
}
