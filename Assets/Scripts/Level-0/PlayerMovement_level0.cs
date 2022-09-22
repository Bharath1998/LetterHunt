
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class PlayerMovement_level0 : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;
    private Animator anim;
    private Vector2 movement;
    bool facingRight = true;
    bool wordFormed = true;
    //List to store Characters collected
    public List<string> inventory;
    public static string target;
    GameObject gameObject;
	public TMP_Text wordTMP;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inventory = new List<string>();

        try
        {
            target = LetterSpawner_level0.target_word;
            print("target="+target);
            int n = target.Length;
            string temp = new string('_',n);
            wordTMP.text = temp;
            
        
        }
        catch (NullReferenceException e)
        {
        
        }
		
    }

    // Update is called once per frame
    void Update()
    {

        movement = new Vector2(Input.GetAxisRaw("Horizontal"),0).normalized ;
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude * 3f));
        if(Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            float dirX = Input.GetAxisRaw("Horizontal");
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
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Letter")
        {
            print("HEYYY");
            Vector3 oldPosition = other.gameObject.transform.position;
            Vector3 oldscale = other.gameObject.transform.localScale;
            Destroy(other.gameObject);
            string characterType = other.gameObject.GetComponent<CollectableScript>().CharacterType;
            try
                {
                
            char lastCharacter = characterType[characterType.Length - 1];
            target = LetterSpawner_level0.target_word;
            string wordtmptext=wordTMP.text;
            char[] arr2 = wordtmptext.ToCharArray();
            
            if (target.Contains(lastCharacter)){
                int idx = target.IndexOf(lastCharacter);
                arr2[idx] = lastCharacter;

            }
                else
                {
                    gameObject = Resources.Load("a/red_a_b_" + char.ToLower(lastCharacter)) as GameObject;
                    if(gameObject != null)
                    {
                        // print("working");
                    }
                    GameObject spawnedLetter = Instantiate(gameObject);
                    spawnedLetter.transform.position = oldPosition;
                    spawnedLetter.transform.localScale = oldscale;
                    Destroy(spawnedLetter, 1);

                }
            wordTMP.text = new string(arr2);
                
            if(wordTMP.text == target){
                // Change to next level (for now level 1) and so on.
                StartCoroutine(LoadLevel1 ());
            }
            }
            catch (NullReferenceException e)
            {
   
            }

        }
    }

     IEnumerator LoadLevel1 () {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
        // Load Next Scene
        SceneManager.LoadScene("Level 1");
    }
}
