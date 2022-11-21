using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static DataCollection;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame(){
        SceneManager.LoadScene("Level0");
    }

    public void Tutorials(){
        SceneManager.LoadScene("Tutorial");
    }
    public void SkipTutorial(){
        SceneManager.LoadScene("RoadMap");
    }

    public void GoToLvl1(){
		DataCollection.levelIndicator = 1;
        SceneManager.LoadScene("Level02-Final");
    }

    public void GoToLvl2(){
		DataCollection.levelIndicator = 2;
        SceneManager.LoadScene("Final_Level2");
    }

 	public void GoToLvl3(){
		DataCollection.levelIndicator = 3;
         SceneManager.LoadScene("Level 3");
    }

    public void GoToLvl4(){
        DataCollection.levelIndicator = 4;
        SceneManager.LoadScene("Level 1");
    }
    public void GoToLvl5(){
        DataCollection.levelIndicator = 5;
        SceneManager.LoadScene("Level 6");
    }
    public void GoToLvl6(){
        DataCollection.levelIndicator = 6;
        SceneManager.LoadScene("LevelRO");
    }

    public void GoToLvl7(){
        DataCollection.levelIndicator = 7;
        SceneManager.LoadScene("lvl9");
    }

     public void GoToLvl8(){
        DataCollection.levelIndicator = 8;
        SceneManager.LoadScene("lvl8");
    }


    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
