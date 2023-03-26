using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{

    float speed = 0.1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.y-= speed;
        transform.position = pos;
        if (ScreenHelper.ScreenSeeker(pos) == false)
        {
            Destroy(gameObject);
        }
    }
}
