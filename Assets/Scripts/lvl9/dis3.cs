using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dis3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float toggleTime=4;
    public float currTime;
    public bool enabled1=true;
    public bool enabled2=true;

    private GameObject platform_set3;
    // private GameObject platform_set3a;

    void Start()
    {
        platform_set3=GameObject.Find("p3_da");
        platform_set3.SetActive(enabled1);
        // platform_set3a=GameObject.Find("p3_da2");
        // platform_set3a.SetActive(enabled1);
    }

    // Update is called once per frame
    void Update()
    {
        currTime+=Time.deltaTime;
        if(currTime>=toggleTime){
            currTime =0;
            togglePlatform();
        }
    }

    void togglePlatform(){
        enabled1=!enabled1;
        platform_set3.SetActive(enabled1);
        // enabled2=!enabled2;
        // platform_set3a.SetActive(enabled2);

    }
}
