using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
                Debug.Log("hit detected");

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("hit detected");

        
    }

    private void onTriggerEnter2D(Collider2D other){
        Debug.Log("hit detected");
    }

    void onCollisionEnter(Collision other){
        Debug.Log("hit detected");
        Destroy(other.gameObject);
    }
}
