using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour   
{
    public Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    CombinedHelperScript Helper;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Helper = gameObject.AddComponent<CombinedHelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.5f;
        anim.SetBool("Walk", false);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 1.5f;
            print("Left Shift Pressed");
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            sr.flipX = false;
            print("D Key Pressed");
            anim.SetBool("Walk", true);
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            sr.flipX = true;
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
    }
}
