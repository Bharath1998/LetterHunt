using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartGame(){
        // For now level 1 - maybe restart at current level using build index -1
        Debug.Log("Hi");
        SceneManager.LoadScene("Level 1");
    }

    public void ExitToMain(){
        Debug.Log("Byee");
        SceneManager.LoadScene("Menu");
    }
    
  
}
