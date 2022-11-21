using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        Debug.Log("Initializing Health Bar");
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider = GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;
    }
}
