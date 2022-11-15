using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearing : MonoBehaviour
{
    public bool enabled=true;
    public float currTime=0;
    private GameObject platform_set1;
    private GameObject platform_set2;
    void Start()
    {
        platform_set1=GameObject.Find("p1");
        platform_set1.SetActive(false);
        // platform_set2=GameObject.Find("p2");
        // platform_set2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
     {
         Debug.Log("First Step");
         if (other.gameObject.tag == "Player" && gameObject.tag=="dp1")
         {
            //  Debug.Log(platform_set1);
            //  Debug.Log("jkbjknjn Step"+gameObject.tag);
             platform_set1.SetActive(true);
            //  Debug.Log("have set p1 active Step");
         }
        //  else if (other.gameObject.tag == "Player" && gameObject.tag=="dp2")
        //  {
        //      platform_set2.SetActive(true);
        //  }

     }

    void OnTriggerExit2D(Collider2D other)
     {

         if (other.gameObject.tag == "Player" && gameObject.tag=="dp1")
         {
             platform_set1.SetActive(false);
         }

        // else if (other.gameObject.tag == "Player" && gameObject.tag=="dp2")
        //  {
        //      Debug.Log("How Done Step");
        //      platform_set2.SetActive(false);
        //  }

     }

}
