using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveGroupEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private bool IsMovingLeft = false;
    public EnemyShip Ship1;
    public EnemyShip Ship2;
    public EnemyShip Ship3;
    public EnemyShip Ship4;
    public EnemyShip Ship5;
    public bool  DeadOrAlive = true;
    private float speed= 0.1f;
    private List<EnemyShip> GroupShip = new List<EnemyShip>();
    private System.Random rndmGenerator = new System.Random();
    void Start()
    {
        GroupShip.Add(Ship1);
        GroupShip.Add(Ship2);
        GroupShip.Add(Ship3);
        GroupShip.Add(Ship4);
        GroupShip.Add(Ship5);
        InvokeRepeating("GroupShoot",1.0f,1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroupShip.RemoveAll(item => item == null);
        if (GroupShip.Count == 0) 
        {
            
            DeadOrAlive = false;
            CancelInvoke();
            return;
        }
        
        if (IsMovingLeft == true)
        {
            float min = Minx();
            float stepx = min - speed;
                if(stepx < -11)
                {
                    IsMovingLeft = false;
                }
                else
                {
                     transform.position = new Vector3(transform.position.x -speed,
                    transform.position.y,
                    0);
                }
        }
        else
        {
            float max = Maxx();
            float stepx = max + speed;
                if(stepx > 11)
                 {
                    IsMovingLeft = true;
                 }
                else
                {
                    transform.position = new Vector3(transform.position.x + speed,
                    transform.position.y,
                    0);
                }
        }
        

        
    }
    float Maxx()
    {
        int i = 0;
        float max = float.MinValue;
        while (i<GroupShip.Count)
        {
            if(GroupShip[i].transform.position.x > max)
            {
                max = GroupShip[i].transform.position.x;
            }
            i++;
        }
        return max;
    }
    float Minx()
    {
        int i = 0;
        float min = float.MaxValue;
        while (i<GroupShip.Count)
        {
            if(GroupShip[i].transform.position.x < min)
            {
                min = GroupShip[i].transform.position.x;
            }
            i++;
        }
        return min;
    }
    void GroupShoot()
    {
        int randomIndex = rndmGenerator.Next(GroupShip.Count);
        GroupShip[randomIndex].SuperPuperMegaUltraGiperVistrelKrutoiPulei();
        
    }
}
