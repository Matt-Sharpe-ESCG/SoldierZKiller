using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Player : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletprefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletprefab, firePoint.position, firePoint.rotation);   
    }

}
