using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating_obstacle : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotation;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation * moveSpeed * Time.deltaTime);
    }

    Rigidbody2D rb;

    GameObject target;

    float moveSpeed;

    Vector3 directionToTarget;

    public static float currentTime;

    PlayerMovement playerMovement;

    public static bool kill = false;

    [SerializeField]
    public static int enemiesKilled = 0;

    bool isEven = false;

    // Start is called before the first frame update
    void Start()
    {
        // timer currentTime =

        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 2f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                //Destroy(collision.gameObject);
                // Debug.Log(gameObject.name);
                // EnemySpawnerScript.spawnAllowed = false;
                playerMovement =
                    collision.gameObject.GetComponent<PlayerMovement>();
                playerMovement.TakeDamage(100);
                break;
        }
    }
}
