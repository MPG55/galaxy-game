using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed=0.2f;
    public int damage = 5;

    
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.y+= speed;
        transform.position = pos;
        if (ScreenHelper.ScreenSeeker(pos) == false)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D( Collider2D otherColllider)
    {
    GameObject otherObject = otherColllider.gameObject;
    EnemyShip enemyScript = otherObject.GetComponent<EnemyShip>();
    if (enemyScript != null)
    {
     enemyScript.health -= damage;
     Destroy(gameObject);
     if(enemyScript.health <=0)
     {
        enemyScript.DestroyEnemyShip();

     }
    }
    }
}
