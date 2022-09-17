using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;
    private Animator anim;
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
        float dirX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(dirX * 7f, player.velocity.y);

        if(Input.GetKey(KeyCode.W))
        {
            player.velocity = new Vector2(player.velocity.x,7);
        }
        if(dirX > 0f){
            anim.SetBool("running",true);
        }
        else if (dirX < 0f)
        {   
            anim.SetBool("running",true);
        }
        else{
            anim.SetBool("running",false);

        }


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
    }
}
