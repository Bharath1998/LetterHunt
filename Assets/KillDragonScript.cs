using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDragonScript : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Enemy"){
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        
    }
}
