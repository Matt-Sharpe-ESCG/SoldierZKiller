using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    public Transform firePointEnemy;
    public GameObject bulletprefab;
    public Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float eHealth;
    private float timer;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()  // Enemy Soldier Firing Sequence
    {
        timer += Time.deltaTime;    

        if (timer > 0.2f)
        {
            timer = 0;
            shoot();
            anim.SetBool("Enemy Shoot", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)   // Damage Sub-Section 
    {
        if (collision.gameObject.CompareTag("Bullet_Player"))
        {
            eHealth = eHealth - 1;
        }
        if (eHealth == 0)
        {
            Die();
        }
    }
    void shoot()    // Summons Bullets Fired By The Enemy Soldier
    {
        Instantiate(bulletprefab, firePointEnemy.position, Quaternion.identity);
    }
    void Die()  //Trigger For Death Animation
    {
        anim.SetBool("Die", true);
    }
}
