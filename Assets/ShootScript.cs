using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public float LaunchForce;
    public BulletBarScript bulletBar;
    public GameObject Bullet;
    [SerializeField]
    public static int totalBullets = 0;

    

    public int maxBulletVal = 100;

    [SerializeField]
    public static int currentBulletVal;


    // Start is called before the first frame update
    void Start()
    {

        bulletBar = new BulletBarScript();
        currentBulletVal = maxBulletVal;
        bulletBar.SetMaxHealth(currentBulletVal);
    }
    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("space"))
        {
            totalBullets += 1;
            int bulletsRemaining = 100 - totalBullets;
            if(bulletsRemaining > 0){
                bulletBar.SetHealth(100 - totalBullets);
                Shoot();
            }
            
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