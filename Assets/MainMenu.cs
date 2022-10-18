using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
