using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
         
        private float speed=0.2f;
    public int damage = 5;
    
    
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
