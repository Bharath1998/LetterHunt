using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


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
