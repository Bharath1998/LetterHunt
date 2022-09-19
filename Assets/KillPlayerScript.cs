using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
    	if(collision.gameObject.name == "Enemy"){
    		Destroy(gameObject);
    		Camera cam = Camera.main;
    		GameObject newCam = new GameObject("newMainCam");
    		newCam.AddComponent<Camera>();
            SceneManager.LoadScene("Game Over");
    		
    	}
    	
    }
}
