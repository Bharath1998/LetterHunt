using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused=false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Hellooo Can you please update the Pause Menu?");

        if(Input.GetKeyDown(KeyCode.P)){

            // Debug.Log("Hellooo I am in pausing menu");
            if (isGamePaused){
                Resume();
            }
            else{
                Pause();
            }
        }
        
        
    }
    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Debug.Log("sss");

    }
    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

}
