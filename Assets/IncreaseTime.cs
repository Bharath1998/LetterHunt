using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTime : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool kill = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            kill = true;
            Destroy(this.gameObject);
        }
    }
}
