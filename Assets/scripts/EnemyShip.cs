using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private  AudioSource SoundsEnemyShip;
    public AudioClip Explosion;
    public int health = 25;
    public GameObject BonusOriginal;
    public Animator spriteAnim;
    public GameObject enemyBulletOriginal;
    private System.Random randomGEN = new System.Random();
    void Start()
    {
        SoundsEnemyShip = GetComponent<AudioSource>();
    }
    public void SuperPuperMegaUltraGiperVistrelKrutoiPulei()
    {
        GameObject newBullet = Instantiate(enemyBulletOriginal);
        newBullet.transform.position = transform.position;
    }
    public void DestroyEnemyShip()
    {
        transform.parent = null;
        spriteAnim.SetBool("IsDead",true);
        
        SoundsEnemyShip.PlayOneShot(Explosion);

    }

    public void OnDestroyAnimationEnd()
    {
        double numberRNDM = randomGEN.NextDouble();
        if (numberRNDM > 0.9){
            GameObject newBonus = Instantiate(BonusOriginal);
            newBonus.transform.position = transform.position;
         
        }
        Destroy(gameObject);
    }
}
