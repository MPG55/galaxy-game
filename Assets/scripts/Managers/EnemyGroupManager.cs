using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupManager : MonoBehaviour
{   public GameObject egmFirst;
    
    public PassiveGroupEnemy CreateEnemyGroup()
    {
        
         GameObject enGroupNew = Instantiate(egmFirst);
         PassiveGroupEnemy groupObj = enGroupNew.GetComponent<PassiveGroupEnemy>();
         return groupObj;
    }
    
}
