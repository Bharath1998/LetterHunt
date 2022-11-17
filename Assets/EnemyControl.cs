using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyControl : MonoBehaviour
{

	Rigidbody2D rb;
	GameObject target;
	float moveSpeed;
	Vector3 directionToTarget;
    public static float currentTime;
    PlayerMovement playerMovement;
    public static bool kill = false;
    [SerializeField]
    public static int enemiesKilled = 0;
    bool isEven = false;

    // Start is called before the first frame update
    void Start()
    {
        // timer currentTime = 
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
    	MoveMonster();   
    }
    void OnCollisionStay2D(Collision2D collision){
        switch(collision.gameObject.tag){
    		case "Player":
                //Destroy(collision.gameObject);
                // Debug.Log(gameObject.name);
                // EnemySpawnerScript.spawnAllowed = false;
                playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                
                var timeSpan = System.DateTime.Now;

                if(timeSpan.Second %2 == 0){
                    if(isEven == false){

                        playerMovement.TakeDamage();
                    }
                    isEven = true;
                }
                else{
                    isEven = false;
                }
                

	    		break;
        }

    }
    void OnCollisionEnter2D(Collision2D collision){
    	switch(collision.gameObject.tag){
    		case "Player":
                //Destroy(collision.gameObject);
                // Debug.Log(gameObject.name);
                // EnemySpawnerScript.spawnAllowed = false;
                playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                
                var timeSpan = System.DateTime.Now;
                if(timeSpan.Second %2 == 0){
                    if(isEven == false){
                        playerMovement.TakeDamage();
                    }
                    isEven = true;
                }
                else{
                    isEven = false;
                }
                

	    		break;
	    	case "Bullet":
                enemiesKilled += 1;
	    		Destroy(collision.gameObject);
	    		// if (gameObject.tag == "Enemy1")
	    		// {
                //     // timer.currentTime += 5 * Time.deltaTime;
                //     // Debug.Log(timer.currentTime);
                //     kill = true; 

	    			
	    		// }
	    		Destroy(gameObject);
	    		break;
    	}

    	

    }

    void MoveMonster(){
    	if (target != null){
    		directionToTarget = (target.transform.position - transform.position).normalized;
    		rb.velocity = new Vector2 (directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
    	}
    	else{
    		rb.velocity = Vector3.zero;
    	}
    }
}
