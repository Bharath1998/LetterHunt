using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;
    private Animator anim;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(dirX * 7f, player.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x,7);
        }
        if(dirX > 0f){
            anim.SetBool("running",true);
        }
        else if (dirX < 0f)
        {   
            anim.SetBool("running",true);
        }
        else{
            anim.SetBool("running",false);

        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Letter")
        {
            Destroy(other.gameObject);
        }
    }
}
