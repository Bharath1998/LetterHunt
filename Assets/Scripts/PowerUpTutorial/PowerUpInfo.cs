using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DataCollection;


public class PowerUpInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoadRoadMap());
    }

    IEnumerator LoadLevel1() {
        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);
        // Load Next Scene
        DataCollection.levelIndicator = 1;
        SceneManager.LoadScene("Level 1");
    }
    
    IEnumerator LoadRoadMap() {
        yield return new WaitForSeconds(7f);
        Destroy(this.gameObject);
        // Load Next Scene
        SceneManager.LoadScene("RoadMap");
    }
}
