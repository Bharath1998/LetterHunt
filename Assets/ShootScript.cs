using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float LaunchForce;
    public GameObject Bullet;
    [SerializeField]
    public static int totalBullets = 0;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("space"))
        {
            totalBullets += 1;
            Shoot();
        }     
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, transform.position, transform.rotation);
        BulletIns.transform.Rotate(0, 0, -90.0f, Space.Self);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);   
        Destroy(BulletIns.gameObject, 2f);
    }
}