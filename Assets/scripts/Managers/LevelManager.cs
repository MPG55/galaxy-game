using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private AudioSource music;
    private EnemyGroupManager groupManager;
    private PassiveGroupEnemy currentGroup;
    private int groupsCount = 1;
    
    public void Start()
    {
        groupManager = GetComponent<EnemyGroupManager>();
        currentGroup = groupManager.CreateEnemyGroup();
        music = GetComponent<AudioSource>();
        music.Play();
    }
   
    public void Update()
    {
     if (currentGroup.DeadOrAlive == false)
     {
        groupsCount -= 1;
        Destroy(currentGroup);
        if (groupsCount > 0)
        {
            currentGroup = groupManager.CreateEnemyGroup();
        }
        else
        {
             SceneManager.LoadSceneAsync(SceneID.winSceneID);
        }
        
     } 
    }
}
