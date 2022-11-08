using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class EnemySpawnerScript : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;
    public static int spawnedMonsters = 0;
    int spawnLimit = 9;

    void Start()
    {
        
        // spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 3f, 6f);


        Scene currentScene = SceneManager.GetActiveScene ();
 
         // Retrieve the name of this scene.
        string sceneName = currentScene.name;
        if (sceneName == "Level02-Final") 
        {
            spawnLimit = 3;
        }
        else if (sceneName == "Final_Level2")
        {
            // print("LEVEL 2");
            spawnLimit=5;
            // print("inside if TARGET FROM PLAYER MOVE "+target);
        }
        else if (sceneName == "Level 3")
        {
            // print("LEVEL 2");
            spawnLimit=7;
            // print("inside if TARGET FROM PLAYER MOVE "+target);
        }
        else if (sceneName == "Level 1") 
        {
            spawnLimit = 9;
        }
        else if (sceneName == "Level 2")
        {
            // print("LEVEL 2");
            spawnLimit=15;
            // print("inside if TARGET FROM PLAYER MOVE "+target);
        }
    }

    void SpawnAMonster(){
        // if(spawnAllowed){
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            if(spawnedMonsters != spawnLimit){
                Instantiate(monsters [randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                spawnedMonsters++;
            }
            
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
