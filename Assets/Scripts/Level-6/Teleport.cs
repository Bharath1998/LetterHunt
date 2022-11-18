using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject portal;
    public GameObject portal2;
    private GameObject player;
    private bool door1=true;
    private bool door1_final=false;


     private void Start() {
        player = GameObject.FindWithTag("Player");

        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag=="Player"){
            if(this.tag=="Door1"){
                player.transform.position = new Vector2(portal2.transform.position.x-2, portal2.transform.position.y);
            }
            else if(this.tag=="Door2"){
            player.transform.position = new Vector2(portal.transform.position.x+2, portal.transform.position.y);

            }
            else if(this.tag=="Door2_1"){
            player.transform.position = new Vector2(portal2.transform.position.x+2, portal2.transform.position.y);

            }
            else if(this.tag=="Door2_2"){
            player.transform.position = new Vector2(portal.transform.position.x-2, portal.transform.position.y);

            }
            else if(this.tag=="Door3_1"){
            player.transform.position = new Vector2(portal2.transform.position.x+2, portal2.transform.position.y);

            }
            else if(this.tag=="Door3_2"){
            player.transform.position = new Vector2(portal.transform.position.x-2, portal.transform.position.y);

            }


        }
    }


}
