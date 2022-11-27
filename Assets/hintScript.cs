using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hintScript : MonoBehaviour
{
    public static float timer;

    public GameObject button;

    public static string target_word;

    public Canvas imageCanvas;


    // public static bool isGamePaused = false;


    // public GameObject musicGameObject;


    void Start()
    {
        // isGamePaused = false;
        Time.timeScale = 1f;
        timer = Timer.currentTime;
        button.SetActive(false);
        GameObject canvasObject = GameObject.Find("ImageCanvas");
        if (canvasObject != null)
        {
            imageCanvas = canvasObject.GetComponent<Canvas>();
        }

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

    }

    void Update()
    {
        target_word = PlayerMovement.target;
        timer = (int) Timer.currentTime;
        if (timer == 20)
        {
            button.SetActive(true);
            return;
        }
       
    }

    

    public void hintOnClick()
    {
        // musicGameObject.SetActive(false);
        // isGamePaused = true;
        Time.timeScale = .00000000001f;
        StartCoroutine(ResumeGame());
        GameObject newObject = new GameObject("hintImage");
        newObject.transform.SetParent(imageCanvas.transform);
        newObject.transform.position = new Vector3(950, 600, 1000);
        newObject.transform.localScale = new Vector3(2, 2, 0);
        newObject.AddComponent<Image>();
        newObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("HintImages/" + target_word);
        
        Destroy(newObject, 0.2f);
        button.SetActive(false);
        
        

    }

     IEnumerator ResumeGame()
    {
        print("in resume game");
        // musicGameObject.SetActive(true);
        // isGamePaused = false;
        yield return new WaitForSeconds(Time.timeScale * 3f);
        Time.timeScale = 1f;
        // print(isGamePaused);
         
    }
}
