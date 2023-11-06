using NUnit.Framework;
using System;
using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    public float speed = 20f; 
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        //rb.velocity = transform.right * speed;
       
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
