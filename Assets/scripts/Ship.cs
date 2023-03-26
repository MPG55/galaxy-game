using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{   
    private AudioSource SoundsShip;
    private static float MAX_HEALTH = 25.0f;
    private float Speed=0.1f;
    public GameObject bulletOriginal;
    private float health = MAX_HEALTH;
    private int hitCount = 0;
    public AudioClip BulletShot;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;
    private List<GameObject> hpList = new List<GameObject>();
    void Start()
    {
        hpList.Add(hp1);
        hpList.Add(hp2);
        hpList.Add(hp3);
        hpList.Add(hp4);
        hpList.Add(hp5);
        SoundsShip = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        
        bool KeyShot = Input.GetKeyUp(KeyCode.Space);
        if (KeyShot == true)
        {
            GameObject bulletClone = Instantiate(bulletOriginal);
            bulletOriginal.transform.position = transform.position;
            SoundsShip.PlayOneShot(BulletShot);
        }
    }

    void FixedUpdate()
    {
    bool KeyLeft = Input.GetKey(KeyCode.A);
        if (KeyLeft == true)
        {
         Vector3 pos = transform.position;
         pos.x-= Speed; 
         transform.position = pos;

        }
        bool KeyRight = Input.GetKey(KeyCode.D);
        if (KeyRight == true)
        {
         Vector3 pos = transform.position;
         pos.x+=Speed; 
         transform.position = pos;
        }
        bool KeyUp = Input.GetKey(KeyCode.W);
        if (KeyUp == true)
        {
         Vector3 pos = transform.position;
         pos.y+= Speed; 
         transform.position = pos;

        }
        bool KeyDown = Input.GetKey(KeyCode.S);
        if (KeyDown == true)
        {
         Vector3 pos = transform.position;
         pos.y-= Speed; 
         transform.position = pos;

        }
    }

    void OnTriggerEnter2D(Collider2D otherColllider)
    {
        GameObject otherObject = otherColllider.gameObject;
        EnemyBullet bulletScript = otherObject.GetComponent<EnemyBullet>();
        if (bulletScript != null)
        {
            health -= bulletScript.damage;
            onHit();
            Destroy(otherObject);
            if(health <= 0)
            {
                SceneManager.LoadSceneAsync(SceneID.loseSceneID);
                Destroy(gameObject);
            }
        }
        HealthBonus bonusScript = otherObject.GetComponent<HealthBonus>();
        if (bonusScript != null)
        {
            Destroy(otherObject);
            HealthBNS();
        }
    
    }
    void HealthBNS()
    {
        print("HEALTH BONUS COLLECTED");
        health = MAX_HEALTH;
        hitCount = 0;
        foreach (GameObject currentItem in hpList)
        {
            currentItem.SetActive(true);
            
        }
    }
    void onHit()
    {
        hpList[hitCount].SetActive(false); 
        hitCount += 1;
    }
}

