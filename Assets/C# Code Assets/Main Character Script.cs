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

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        int speed = 1;
        float jumpFactor = 150f;
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

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Q))
        {
            print("Right Shift and A Key Pressed");
            anim.SetBool("Roll", true);
        }
        else
        {
            anim.SetBool("Roll", false);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Q))
        {
            print("Right Shift and A Key Pressed");
            anim.SetBool("Roll", true);
        }
        else
        {
            anim.SetBool("Roll", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space Pressed");
            anim.SetBool("Jump", true);
            //transform.position = new Vector2(transform.position.y + (jumpFactor * Time.deltaTime), transform.position.x);
            rb.AddForceY(jumpFactor, ForceMode2D.Impulse);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
}
