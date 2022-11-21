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

    float startingTime = 2f;

    public TMP_Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
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
