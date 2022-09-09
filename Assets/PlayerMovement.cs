using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
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



    }
}
