
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Player : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletprefab;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Shoot 2", false);
        anim.SetBool("Shoot 1", false);
        if (Input.GetKey(KeyCode.Return))
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
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        
    }
}
