using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemyScript : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    public float peHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;
        anim.SetBool("Run", true);        
    }
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            flip();
            currentPoint = PointA.transform;
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform;
        }
        anim.SetBool("Attack", false);
        anim.SetBool("Injury", false);
        anim.SetBool("Die", false);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Attack", true);
        }

        if (collision.CompareTag("Bullet_Player"))
        {
            peHealth = peHealth - 1;
            anim.SetBool("Injury", true);
            if (peHealth < 0)
            {
                anim.SetBool("Die", true);
                //Die();
            }
        }
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    /* void Die()
     {
         StartCoroutine(Killed(0.5f));
     }

     IEnumerator Killed(float, 1f)
     {
         yield return new WaitForSeconds(1);
         Despawn();
     }*/



    /*void Despawn()
    {
        Destroy(gameObject);
    }*/
}
