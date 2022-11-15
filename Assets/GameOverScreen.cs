using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataCollection;


public class GameOverScreen : MonoBehaviour
{
    public void RestartGame(){

        // SceneManager.LoadScene("RoadMap");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ProceedNextLevel() {
        // Needs to be generic
		DataCollection.levelIndicator = 2;
		SceneManager.LoadScene("Level 2");
    }

    public void ExitToMain(){
        SceneManager.LoadScene("Menu");
    }

    public void ExitToLevelMap(){
        SceneManager.LoadScene("RoadMap");
    }
    
  
}
