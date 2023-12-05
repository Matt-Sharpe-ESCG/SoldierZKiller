using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class MainCharacterScript : MonoBehaviour   
{
    public Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;  
    Vector3 dir;
    public GameObject weapon;
    playerHealth healthInfo;
    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject bulletprefab;
    public GameObject player;
    public AmmoControllerPlayer Ammuntion;
    int ammoCount = 30;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //dir = Vector3.zero;
    }

    private void Flip(bool left)
    {
        sr.flipX = left;
    }

    void Update()
    {
        int speed = 1;
        float jumpFactor = 250f;
        anim.SetBool("Walk", false);

        dir = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2;
            print("Left Shift Pressed");
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            print("D Key Pressed");
            Flip(false);
            anim.SetBool("Walk", true);
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);           
        }

        if (Input.GetKey(KeyCode.A))
        {
            Flip(true);
            anim.SetBool("Walk", true);
            print("A Key Pressed");
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }

        if (Input.GetKey(KeyCode.E)) 
        {
            print("E Key Pressed");
            anim.SetBool("Crouch", true);
        }
        else
        {
            anim.SetBool("Crouch", false);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Q))
        {
            print("Right Shift and A Key Pressed");
            anim.SetBool("Roll", true);
            rb.AddForceX(10, ForceMode2D.Impulse);
        }
        else
        {
            anim.SetBool("Roll", false);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Q))
        {
            print("Right Shift and A Key Pressed");
            anim.SetBool("Roll", true);
            rb.AddForceX(10, ForceMode2D.Impulse);
        }
        else
        {
            anim.SetBool("Roll", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space Pressed");
            anim.SetBool("Jump", true);
            //transform.position = new Vector2(transform.position.y + (j umpFactor * Time.deltaTime), transform.position.x);
            rb.AddForceY(jumpFactor, ForceMode2D.Impulse);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

        anim.SetBool("Shoot 2", false);
        anim.SetBool("Shoot 1", false);
        anim.SetBool("Reload", false);

        if (Input.GetKeyDown(KeyCode.Return) && ammoCount > 0)
        {
            shoot();
            anim.SetBool("Shoot 2", true);
            ammoCount = ammoCount - 1;
            anim.SetInteger("Ammo", ammoCount - 1);
        }

        if (Input.GetKeyDown(KeyCode.Return) && Input.GetKey("A"))
        {
            shoot();
            anim.SetBool("Shoot 1", true);
        }

        if (Input.GetKeyDown(KeyCode.Return) && Input.GetKey("D"))
        {
            shoot();
            anim.SetBool("Shoot 1", true);
        }

        if (Input.GetKeyDown(KeyCode.Return) && Input.GetKey("E"))
        {
            shoot();
            anim.SetBool("Crouch Shoot", true);
            ammoCount = ammoCount - 1;
            anim.SetFloat("Ammo", ammoCount - 1);
        }

        if (ammoCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                anim.SetBool("Reload", true);
                ammoCount = 30;
            }
        }
    }
    void shoot()
    {
        Vector3 bulletDirection;
        GameObject obj;

        if (player.GetComponent<SpriteRenderer>().flipX == true)
        {
            bulletDirection = -transform.right * 20f;
            obj = Instantiate(bulletprefab, firePointLeft.position, firePointLeft.rotation);
        }
        else
        {
            bulletDirection = transform.right * 20f;
            obj = Instantiate(bulletprefab, firePointRight.position, firePointRight.rotation);
        }
        obj.GetComponent<Rigidbody2D>().velocity = bulletDirection;

    }
}
