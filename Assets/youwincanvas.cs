using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youwincanvas : MonoBehaviour
{
    public void GoNextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level02-Final") 
        {
            DataCollection.levelIndicator = 2;
            SceneManager.LoadScene("Final_Level2");
        }
        else if (sceneName == "Final_Level2") 
        {
            DataCollection.levelIndicator = 3;
            SceneManager.LoadScene("Level 3");
        }
        else if (sceneName == "Level 3")
        {
            DataCollection.levelIndicator = 4;
            SceneManager.LoadScene("Level 1");
        }
        else if (sceneName == "Level 1")
        {
            DataCollection.levelIndicator = 5;
            SceneManager.LoadScene("Level 6");
        }
        else if (sceneName == "Level 6")
        {
            DataCollection.levelIndicator = 6;
            SceneManager.LoadScene("LevelRO");
        }
        else if (sceneName == "LevelRO")
        {
            DataCollection.levelIndicator = 7;
            SceneManager.LoadScene("lvl9");
        }
        else if (sceneName == "lvl9")
        {
            DataCollection.levelIndicator = 8;
            SceneManager.LoadScene("lvl8");
        }
        else if (sceneName == "lvl8")
        {
            // Change when new level is added.
            DataCollection.levelIndicator = 9;
            SceneManager.LoadScene("lvl11");
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level02-Final") 
        {
            SceneManager.LoadScene("Level02-Final");
        }
        else if (sceneName == "Final_Level2") 
        {
            SceneManager.LoadScene("Final_Level2");
        }
        else if (sceneName == "Level 3") 
        {
            SceneManager.LoadScene("Level 3");
        }
        else if (sceneName == "Level 1") 
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (sceneName == "Level 6") 
        {
            SceneManager.LoadScene("Level 6");
        }
        else if (sceneName == "LevelRO")
        {
            SceneManager.LoadScene("LevelRO");
        }
        else if (sceneName == "lvl9")
        {
            SceneManager.LoadScene("lvl9");
        }
        else if (sceneName == "lvl8")
        {
            SceneManager.LoadScene("lvl8");
        }
        else if (sceneName == "lvl11")
        {
            SceneManager.LoadScene("lvl11");
        }
        else if (sceneName == "urjit-lvl-10")
        {
            SceneManager.LoadScene("urjit-lvl-10");
        }


    }

    public void ToLevelMap()
    {
        SceneManager.LoadScene("RoadMap");
    }
}
