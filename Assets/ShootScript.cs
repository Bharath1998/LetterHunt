using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float LaunchForce;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }     
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, transform.position, transform.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);   
        Destroy(BulletIns.gameObject, 2f);
    }
}