using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int bulletDamage;

    [SerializeField] private HealthController _healthController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }

        if (collision.CompareTag("Enemy"))
        {
            Damage();
        } 

    }

    void Damage()
    {
        _healthController.playerLives = _healthController.playerLives - bulletDamage;
        _healthController.UpdateHealth();
        gameObject.SetActive(true);
    }
}
