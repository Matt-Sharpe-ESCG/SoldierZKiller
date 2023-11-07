using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    float timeToDie;
    void Start()
    {
        timeToDie = 0.5f;
    }
    void Update()
    {
        timeToDie -= Time.deltaTime;
        if (timeToDie < 0f)
        {
            Destroy(gameObject);
        }
    }
}
