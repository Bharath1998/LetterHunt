using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletBarScript : MonoBehaviour
{
    public static Slider slider;
    void Start(){

        slider = GetComponent<Slider>();
     }
    public void SetHealth(int bulletVal){
        slider.value = bulletVal;
    }

    public void SetMaxHealth(int bulletVal){
        slider.maxValue = bulletVal;
        slider.value = bulletVal;
    }

}
