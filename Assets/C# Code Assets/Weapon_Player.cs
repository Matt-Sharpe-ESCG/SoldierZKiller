
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Player : MonoBehaviour
{

    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject bulletprefab;
    public Animator anim;
    public GameObject player;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Shoot 2", false);
        anim.SetBool("Shoot 1", false);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            shoot();
            anim.SetBool("Shoot 2", true);
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
    }

    void shoot()
    {
        Vector3 bulletDirection;
        GameObject obj;

        if( player.GetComponent<SpriteRenderer>().flipX == true)
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
