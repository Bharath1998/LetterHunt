using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DataCollection;
public class Platform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public bool canMove;
    public Transform startPos;
    public GameObject player;
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        nextPos = pos2.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            if(transform.position == pos1.position){
            nextPos = pos2.position;
            }
            if(transform.position == pos2.position){
                nextPos = pos1.position;
            }
            // Debug.Log(nextPos);
            // Debug.Lo

            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
        
        
    }
    private void onDrawGizmos(){
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name == "Player"){
            canMove=true;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.name == "Player"){
            canMove=false;
        }
    }

}
