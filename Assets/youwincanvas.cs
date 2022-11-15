using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class youwincanvas : MonoBehaviour
{
    public void GoNextLevel() {
        // Needs to be generic
		DataCollection.levelIndicator = 2;
		Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        if (sceneName == "Level02-Final")
        {
            SceneManager.LoadScene("Final_Level2");
        }
        else if (sceneName == "Final_Level2"){
            SceneManager.LoadScene("Level 3");
        }
        else if (sceneName == "Level 3"){
            SceneManager.LoadScene("Level 1");
        }
        else if (sceneName == "Level 1"){
            SceneManager.LoadScene("Level 6");
        }
        else if (sceneName == "Level 6"){
            SceneManager.LoadScene("LevelR0");
        }
        else if (sceneName == "LevelRO"){

            SceneManager.LoadScene("lvl9");
        }
        else if(sceneName=="lvl9"){
            // Change when new level is added.
            SceneManager.LoadScene("Win");
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void RestartLevel(){
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
        else if (sceneName == "Level 3"){
            SceneManager.LoadScene("Level 3");
        }
        else if (sceneName == "Level 6"){
            SceneManager.LoadScene("Level 6");
        }
        else if (sceneName == "LevelRO"){

            SceneManager.LoadScene("LevelRO");
        }
        else if(sceneName=="lvl9"){
            SceneManager.LoadScene("lvl9");
        }

    }

    public void ToLevelMap(){
        SceneManager.LoadScene("RoadMap");
    }

}
