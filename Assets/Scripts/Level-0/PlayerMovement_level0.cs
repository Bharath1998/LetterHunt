
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class PlayerMovement_level0 : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;
    private Animator anim;
    private Vector2 movement;
    bool facingRight = true;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		
    }

    // Update is called once per frame
    void Update()
    {

        movement = new Vector2(Input.GetAxisRaw("Horizontal"),0).normalized ;
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude * 3f));
        if(Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            float dirX = Input.GetAxisRaw("Horizontal");
            player.velocity = new Vector2(player.velocity.x,6);
        }
        bool flipped = movement.x < 0;
        bool is_still = movement.x == 0;
        if(flipped == true & facingRight == true){
            facingRight = false;
        }
        if(flipped == false & facingRight == false & !is_still){
            facingRight = true;
        }
        this.transform.rotation =
            Quaternion.Euler(new Vector3(0f, !facingRight ? 180f : 0f, 0f));
    }

    private void FixedUpdate(){
        if (movement != Vector2.zero){
            var xMovement = movement.x * 3f * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement,0), Space.World);
        }

    }
}
