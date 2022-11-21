using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : MonoBehaviour
{
    public GameObject shield;

    private bool hasShield;

    // Start is called before the first frame update
    void Start()
    {
        hasShield = false;
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void removeShield()
    {
        shield.SetActive(false);
        hasShield = false;
    }

    void addShield()
    {
        shield.SetActive(true);
        hasShield = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ShieldPowerup")
        {
            Debug.Log("Add shield");

            // shield.SetActive(true);
            addShield();
            Destroy(collision.gameObject);
            Invoke("removeShield", 6f);
        }
        if (hasShield && collision.gameObject.tag == "Enemy1")
        {
            Debug.Log("shield collision");
            Destroy(collision.gameObject);
        }
    }
}
