using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataCollection;


public class GameOverScreen : MonoBehaviour
{
    public void RestartGame(){

        // SceneManager.LoadScene("RoadMap");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        if (sceneName == "Level02-Final")
        {
            SceneManager.LoadScene("Level02-Final");
        }
        else if (sceneName == "Final_Level2"){
            SceneManager.LoadScene("Final_Level2");
        }
        else if (sceneName == "Level 3"){
            SceneManager.LoadScene("Level 3");
        }
        else if (sceneName == "Level 1"){
            SceneManager.LoadScene("Level 1");
        }
        else if (sceneName == "Level 6"){
            SceneManager.LoadScene("Level 6");
        }
        else if (sceneName == "LevelRO"){

            SceneManager.LoadScene("LevelRO");
        }
        else if(sceneName=="lvl9"){
            // Change when new level is added.
            SceneManager.LoadScene("lvl9");
        }
        else if(sceneName=="lvl8"){
            // Change when new level is added.
            SceneManager.LoadScene("lvl8");
        }
        else if(sceneName == "Win"){
            SceneManager.LoadScene("RoadMap");

        }
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
