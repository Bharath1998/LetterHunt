// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;

// using UnityEngine.UI;
// public class Defeat : MonoBehaviour
// {

//     public static bool isGameLost = false;

//     public GameObject defeatMenuUI;

//     public static float currentHealth;


//     // public GameObject musicGameObject;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//         defeatMenuUI.SetActive(false);
//         isGameLost = false;
//         Time.timeScale = 1f;
//         currentHealth = PlayerMovement.cur;
//         print("currentHealth"+ currentHealth);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//         if (currentHealth<=0)
//         {
//             print("Starting this fuckkk");
//             defeatMenuUI.SetActive(true);
//             Time.timeScale = 0f;
       
//         }
//     }


//     // void Restart()
//     // {
//     //     pauseMenuUI.SetActive(false);
//     //     Time.timeScale = 1f;
//     //     isGamePaused = false;
//     //     musicGameObject.SetActive(true);
//     // }

//     // void Pause()
//     // {
//     //     pauseMenuUI.SetActive(true);
//     //     Time.timeScale = 0f;
//     //     isGamePaused = true;
//     //     musicGameObject.SetActive(false);
//     // }
// }
