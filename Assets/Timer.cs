using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using static DataCollection;

public class Timer : MonoBehaviour
{
    public static float currentTime = 0f;

    public static bool kill;

    public static float startingTime = 120f;

    public TMP_Text countdownText;

    public static int score;

    public TMP_Text scoreDefeat;

    public GameObject defeatMenuUI;

    void Start()
    {
        // currentTime = startingTime;
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        if (sceneName == "Level02-Final")
        {

            currentTime = 45f;
        }
        else if (sceneName == "Final_Level2")
        {

            currentTime = 45f;
        }
        else if (sceneName == "Level 3")
        {

            currentTime = 60f;
        }
        else if (sceneName == "Level 1")
        {

            currentTime = 45f;
        }
        else if (sceneName == "Level 6")
        {

            currentTime = 45f;
        }
        else if (sceneName == "LevelRO")
        {

            currentTime = 60f;
        }
        else if (sceneName == "lvl9")
        {

            currentTime = 60f;
        }
        else if (sceneName == "lvl8")
        {

            currentTime = 60f;
        }
        else if (sceneName == "lvl11")
        {

            currentTime = 60f;
        }

        defeatMenuUI.SetActive(false);
        startingTime = currentTime;

    }

    void Update()
    {
        score = PlayerMovement.score;
        kill = IncreaseTime.kill;

        if (kill == true)
        {
            Debug.Log("Previous current time = " + currentTime);
            currentTime += 5;
            Debug.Log("New current time = " + currentTime);
        }
        else
        {
            currentTime -= 1 * Time.deltaTime;
        }

        IncreaseTime.kill = false;

        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            StartCoroutine(DataCollection.Upload("TIME_UP"));
            defeatMenuUI.SetActive(true);
            scoreDefeat.text = score.ToString();
            Time.timeScale = 0f;
            // PlayerMovement.killPlayer();
            // SceneManager.LoadScene("Game Over");
        }
    }

    // public float timeValue = 90;
    // public Text timeText;
    // // Start is called before the first frame update

    // // Update is called once per frame
    // void Update()
    // {
    // 	if(timeValue > 0)
    // 	{
    // 		timeValue -= Time.deltaTime;

    // 	}
    // 	else
    // 	{
    // 		timeValue = 0;
    // 	}

    // 	DisplayTime(timeValue);

    // }

    // void DisplayTime(float timeToDisplay)
    // {
    // 	if(timeToDisplay < 0)
    // 	{
    // 		timeToDisplay = 0;
    // 	}

    // 	float minutes = Mathf.FloorToInt(timeToDisplay / 60);
    // 	float seconds = Mathf.FloorToInt(timeToDisplay % 60);

    // 	timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    // }
}
