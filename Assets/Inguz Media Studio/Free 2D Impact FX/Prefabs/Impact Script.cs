using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    float timeToDie;

    // Start is called before the first frame update
    void Start()
    {
        timeToDie = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDie -= Time.deltaTime;
        if (timeToDie < 0f)
        {
            Destroy(gameObject);
        }
    }
}
