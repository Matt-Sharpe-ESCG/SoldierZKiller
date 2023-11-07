using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoControllerPlayer : MonoBehaviour
{
    public int ammo;
    public int maxammo;
    public Image ammoBar;
    
    // Start is called before the first frame update
    void Start()
    {
        maxammo = ammo;
    }

    // Update is called once per frame
    void Update()
    {
        ammoBar.fillAmount = Mathf.Clamp(ammo / maxammo, 0, 1);
    }
}
