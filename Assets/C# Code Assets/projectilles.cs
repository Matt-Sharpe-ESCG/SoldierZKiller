using NUnit.Framework;
using System;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Bullet()
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        bool hits = true;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        MainEnemy enemy = hitInfo.GetComponent<MainEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        PatrolingEnemyScript enemy2 = hitInfo.GetComponent<PatrolingEnemyScript>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
        }

        if (hitInfo.gameObject)
        {
            Bullet() = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (impactEffect != null)
        {
            Destroy(impactEffect);
        }
    }
}
