using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;
    private Animator anim;
    private Vector2 movement;
    bool facingRight = true;
    bool wordFormed = true;
    //List to store Characters collected
    public List<string> inventory;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inventory = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        // float dirX = Input.GetAxisRaw("Horizontal");
        // player.velocity = new Vector2(dirX * 7f, player.velocity.y);

        // if(Input.GetKey(KeyCode.W))
        // {
        //     player.velocity = new Vector2(player.velocity.x,7);
        // }

        // bool flipped = dirX <0 ;
        // transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));


        // if(dirX > 0f){
        //     anim.SetBool("running",true);
        // }
        // else if (dirX  < 0f)
        // {   
        //     anim.SetBool("running",true);
        // }
        // else{
        //     anim.SetBool("running",false);

        // }

        movement = new Vector2(Input.GetAxisRaw("Horizontal"),0).normalized ;
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude * 3f));
        if(Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            float dirX = Input.GetAxisRaw("Horizontal");
            // player.velocity = new Vector2(dirX * 6f, player.velocity.y);
            player.velocity = new Vector2(player.velocity.x,6);
        }
        bool flipped = movement.x <0 ;

        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));



    }

    private void FixedUpdate(){
        if (movement != Vector2.zero){
            var xMovement = movement.x * 3f * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement,0), Space.World);
        }

    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }


    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Letter")
        {
            Destroy(other.gameObject);
            string characterType = other.gameObject.GetComponent<CollectableScript>().CharacterType;
            print("Item Collected: "+ characterType);
            inventory.Add(characterType);
            print("Inventory Count: "+ inventory.Count);
            string items = "";
            for(int i=0;i<inventory.Count;i++)
            {
                items = items+inventory[i]+" ";
            }
            print(items);
        }
        // If he collects all letters needed and then collides, he moves to next level, else game over. use build index+1
        if (other.gameObject.tag == "FinishLevel" && wordFormed)
        {
             SceneManager.LoadScene("Game Over");
        }
    }
}
