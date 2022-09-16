using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerScript : MonoBehaviour
{
	public DatabaseModel data;
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
	        StartCoroutine(Upload());
    		Destroy(gameObject);
    		Camera cam = Camera.main;
    		GameObject newCam = new GameObject("newMainCam");
    		newCam.AddComponent<Camera>();
            SceneManager.LoadScene("Game Over");
    		
    	}
    	
    }
    IEnumerator Upload()
    {
	    data = new DatabaseModel();
	    data.name = "Vini Jr.";
	    data.age = "22";
	    data.position = "Forward";
	    Debug.Log("Started");
	    Debug.Log(UnityWebRequest.EscapeURL(data.Stringify()));

	    UnityWebRequest www = UnityWebRequest.Post("https://data.mongodb-api.com/app/data-sirhi/endpoint/get_entry", UnityWebRequest.EscapeURL(data.Stringify()));
	    www.SendWebRequest();
	    while(!www.isDone)
	    {
		    continue;
	    }

	    if (www.isDone){
		    var data = www.downloadHandler.text;

		    if (www.result != UnityWebRequest.Result.Success)
		    {
			    Debug.Log(www.error);
		    }
		    else
		    {
			    Debug.Log("Data upload complete!");
			    Debug.Log(data);
		    }

		    www.Dispose();

		    yield return null;
	    }
    }
}
