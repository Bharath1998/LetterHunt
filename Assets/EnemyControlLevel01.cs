using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyControlLevel01 : MonoBehaviour
{

    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;
    public static float currentTime;
    PlayerMovement playerMovement;
    public static bool kill = false;


    // Start is called before the first frame update
    void Start()
    {
        // timer currentTime = 
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMonster();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                Destroy(collision.gameObject);
                //StartCoroutine(EnemyControlLevel01.LoadPowerUpTutorial());
                //Debug.Log(gameObject.name);
                //EnemySpawnerScript.spawnAllowed = false;
                //playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                //playerMovement.TakeDamage();

                StartCoroutine(LoadLevel01());

                break;
            case "Bullet":
                Destroy(collision.gameObject);
                //StartCoroutine(EnemyInfo.LoadPowerUpTutorial());
                // if (gameObject.tag == "Enemy1")
                // {
                //     // timer.currentTime += 5 * Time.deltaTime;
                //     // Debug.Log(timer.currentTime);
                //     kill = true; 


                // }
                Destroy(gameObject);

                StopAllCoroutines();
                StartCoroutine(wait());
                StopAllCoroutines();
                StartCoroutine(LoadLevel01Tutorial());
                break;
        }



    }

    void MoveMonster()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    IEnumerator wait()
    {
        print("waiting");
        yield return new WaitForSeconds(3f);
        StartCoroutine(LoadLevel01Tutorial());


    }
    IEnumerator LoadLevel01Tutorial()
    {


        print("ienumerator");
        Destroy(this.gameObject);
        SceneManager.LoadScene("PowerInfo");
        yield return null;
    }
    IEnumerator LoadLevel01()
    {


        //print("ienumerator");
        //Destroy(this.gameObject);
        SceneManager.LoadScene("Level01");
        yield return null;
    }



}
