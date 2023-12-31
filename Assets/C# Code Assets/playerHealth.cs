using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        anim = GetComponent<Animator>();
        anim.SetBool("Die", false);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health == 0)
        {
            anim.SetBool("Die", true);
        }
    }
}
