using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dis2 : MonoBehaviour
{

    private GameObject platform_set1;
    private GameObject platform_set2;
    void Start()
    {

        platform_set2=GameObject.Find("p2");
        platform_set2.SetActive(false);

    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
     {
    
     if (other.gameObject.tag == "Player" && gameObject.tag=="dp2")
         {
             platform_set2.SetActive(true);
         }

     }
    void OnTriggerExit2D(Collider2D other)
     {

    if (other.gameObject.tag == "Player" && gameObject.tag=="dp2")
         {
             platform_set2.SetActive(false);
         }
     }
}
