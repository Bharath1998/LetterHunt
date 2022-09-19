using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{


	public static float currentTime = 0f;
    public static bool kill;
	float startingTime = 30f;

	public TMP_Text countdownText;

	void Start(){
		currentTime = startingTime;
	}

	void Update(){

        kill = EnemyControl.kill;
        
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
		
        EnemyControl.kill = false;

		countdownText.text = currentTime.ToString("0");

		if (currentTime <=0){
			currentTime = 0;
			SceneManager.LoadScene("Game Over");
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
