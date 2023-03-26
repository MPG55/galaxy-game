using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseScript : MonoBehaviour
{
    public void closeGame()
    {
        Application.Quit();
    }
    public void replayGame() 
    {
        SceneManager.LoadSceneAsync(SceneID.gameSceneID);
    }
}
