using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
   public void closeGame()
    {
        Application.Quit();
    }
    public void replayGame() 
    {
        print("REPLAY");
        SceneManager.LoadSceneAsync(SceneID.gameSceneID);
    }
}
