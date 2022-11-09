using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
       public GameObject projectile;
    }

    // Update is called once per frame
    void Update() {

      	float minDist=2;
        GameObject player =  GameObject.FindGameObjectWithTag("player");
		GameObject tower  =  GameObject.FindGameObjectWithTag("tower");
 		float dist = Vector3.Distance(player.transform.position, tower.transform.position);

 		if(dist < minDist) {
		  	 GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
             bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
 		}
        
    }
}
