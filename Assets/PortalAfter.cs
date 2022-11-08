using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAfter : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject blue_door;
    public static float timer;
    void Start()
    {   
        timer=Timer.currentTime;
        blue_door=GameObject.Find("D3_2");
        blue_door.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer=(int)Timer.currentTime;
        if(timer == 105){
            blue_door.SetActive (true);
            // blue_door.GetComponent<BoxCollider2D>().enabled = true;
            return;
        }
    }
}
