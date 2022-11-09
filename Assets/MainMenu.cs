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
         SceneManager.LoadScene("Level 3");
    }

    public void GoToLvl4(){
        SceneManager.LoadScene("Level 1");
    }
    public void GoToLvl5(){
        SceneManager.LoadScene("Level 6");
    }
    public void GoToLvl6(){
        SceneManager.LoadScene("LevelRO");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
