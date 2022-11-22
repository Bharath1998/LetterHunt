using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintScript : MonoBehaviour
{
    // Start is called before the first frame update
    // private GameObject image;
    public static float timer;
    public GameObject button;
    public GameObject image;
    void Start()
    {
        timer=Timer.currentTime;
        
        
        image.SetActive(false);
        button.SetActive(false);
    }

    
    void Update()
    {

        timer=(int)Timer.currentTime;
        print("FROM HINT:"+timer);
        if(timer == 30){
            button.SetActive (true);
            
            return;
        }
        
    }

    public void hintOnClick()
    {
        print("Button CLICKED");
        image = Resources.Load("a/red_a_b_" + char.ToLower(lastCharacter)) as GameObject;
        image.SetActive(true);
        yield return new WaitForSeconds(3);
        image.SetActive(false);
        //Destroy(image,3f);

    }
}
