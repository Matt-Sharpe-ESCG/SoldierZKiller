using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DasMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector3 torque;

    // Start is called before the first frame update
    void Start()
    {
        print("start");

         rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10;

        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            speed = 50;
        }

        if (Input.GetKey("w") == true)
        {
            print("Player Pressed W");
            transform.position = new Vector2(transform.position.x, transform.position.y + (speed *Time.deltaTime));
        }

        if (Input.GetKey("s") == true)
        {
            print("Player Pressed S");
            transform.position = new Vector2(transform.position.x, transform.position.y - (speed*Time.deltaTime));
        }

        if (Input.GetKey("a") == true)
        {
            print("Player Pressed A");
            transform.position = new Vector2(transform.position.x - (speed*Time.deltaTime), transform.position.y );
        }

        if (Input.GetKey("d") == true)
        {
            print("Player Pressed D");
            transform.position = new Vector2(transform.position.x + (speed*Time.deltaTime), transform.position.y );
        }

        if (Input.GetKey("e") == true)
        {
            print("Player Pressed E");
            transform.Rotate(new Vector3(0, 0, 0.25f));
        }

        if (Input.GetKey("q") == true)
        {
            print("Player Pressed Q");
            transform.Rotate(new Vector3(0, 0, -0.25f));
        }
    }
}
