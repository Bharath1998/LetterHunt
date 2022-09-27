using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
    	if (collision.gameObject.name == "Player"){
    		// GameObject en1 = GameObject.Find("Enemy1");
            // GameObject en2 = GameObject.Find("Enemy2");
            // Destroy(en1);
            // Destroy(en2);
            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Enemy1"); // NOTE: only ACTIVE gameObjects will be found
 
            foreach (GameObject go in foundObjects)
                {
                        Destroy(go);
                }

            foundObjects = GameObject.FindGameObjectsWithTag("Enemy2"); // NOTE: only ACTIVE gameObjects will be found
 
            foreach (GameObject go in foundObjects)
                {
                        Destroy(go);
                }

            Destroy(this.gameObject);
            EnemySpawnerScript.spawnedMonsters = 0;
        }
        }
    	
    
}
