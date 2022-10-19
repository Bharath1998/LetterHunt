using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static DataCollection;

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

    public static string target;

    GameObject gameObject;
    public HealthBar healthBar;

    public TMP_Text wordTMP;

    public int maxHealth = 100;

    [SerializeField]
    public static int currentHealth;

    public int damage = 10;

    [SerializeField]
    public static int correctPurpleLetters;
    
    [SerializeField]
    public static int correctYellowLetters;
    
    [SerializeField]
    public static int correctOrangeLetters;

    [SerializeField]
    public static int incorrectPurpleLetters;

    [SerializeField]
    public static int incorrectYellowLetters;

    [SerializeField]
    public static int incorrectOrangeLetters;

    int JumpCount = 0;
    public int MaxJumps = 5; //Maximum amount of jumps (i.e. 2 for double jumps)
    public static string win_string = "_____";
    public static char[] arr_win = win_string.ToCharArray();

    void Start()
    {
        JumpCount = MaxJumps;
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inventory = new List<string>();
        healthBar = new HealthBar();
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth (currentHealth);
        correctPurpleLetters=0;
        correctYellowLetters=0;
        correctOrangeLetters=0;
        incorrectPurpleLetters=0;
        incorrectYellowLetters=0;
        incorrectOrangeLetters=0;



        
        
        // target = "CROWNSA";
        Scene currentScene = SceneManager.GetActiveScene ();
 
         // Retrieve the name of this scene.
        string sceneName = currentScene.name;
 
        if (sceneName == "Level 1") 
        {
            target = LetterSpawner.target_word;
        }
        else if (sceneName == "Level 2")
        {
            print("LEVEL 2");
            target = LetterSpawnerLvl2.target_word;
            print("inside if TARGET FROM PLAYER MOVE"+target);
        }
        print("TARGET FROM PLAYER MOVE"+target);
        int n = target.Length;
        print("n FROM PLAYER MOVE"+n);
        string pattern = "_  ";
        string temp1 = "_  ";
        for (int i = 0; i < n-2; i++) 
        {
            temp1 = temp1 + pattern;
            
        }
        temp1 = temp1 + "_";

        // string temp = new string('_', n);
        // string temp = "_  _  _  _  _";
        wordTMP.text = temp1;
        if (wordTMP.text==null){
            print("NULL");

        }
        else{
            print("DASHES"+wordTMP.text);
        }
            
        
        // catch (NullReferenceException e)
        // {
        //     Debug.Log (e);
        // }
    }

    // Update is called once per frame
    void Update()
    {

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude * 3f));
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            float dirX = Input.GetAxisRaw("Horizontal");

            player.velocity = new Vector2(player.velocity.x, 6);
            // if (JumpCount > 0)
            // {
            // Jump();

            
            // }
        }
        bool flipped = movement.x < 0;

        this.transform.rotation =
            Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }

    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            var xMovement = movement.x * 3f * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement, 0), Space.World);
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    public void TakeDamage(){
    
    if((GameObject.Find("Shield") && GameObject.Find("Shield").activeSelf)==false){
        
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            StartCoroutine(DataCollection.Upload(1, "KILLED"));
            Destroy(this.gameObject);
            target = null;
            Camera cam = Camera.main;
            GameObject newCam = new GameObject("newMainCam");
            newCam.AddComponent<Camera>();
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            
            healthBar.SetHealth (currentHealth);
        }
    }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name.Contains("Enemy") && (GameObject.Find("Shield") && GameObject.Find("Shield").activeSelf)){
            Destroy(other.gameObject);
        }
         
        if (other.gameObject.tag == "ground")
        {
        JumpCount = MaxJumps;
        

        }
        if (other.gameObject.tag == "Letter")
        {
            Vector3 oldPosition = other.gameObject.transform.position;
            Vector3 oldscale = other.gameObject.transform.localScale;
            print (oldPosition);
            Destroy(other.gameObject);
            string characterType =
                other
                    .gameObject
                    .GetComponent<CollectableScript>()
                    .CharacterType;

            // print("Item Collected: "+ characterType);
            // inventory.Add(characterType);
            // print("Inventory Count: "+ inventory.Count);
            // string items = "";
            // for(int i=0;i<inventory.Count;i++)
            // {
            //     items = items+inventory[i]+" ";
            // }
            // print(items);
            string characterColor = other.gameObject.GetComponent<CollectableScript>().letterColor;
            // print(characterColor);
            try
            {
                char lastCharacter = characterType[characterType.Length - 1];
                target = LetterSpawner.target_word;
                string wordtmptext = wordTMP.text;
                char[] arr2 = wordtmptext.ToCharArray();

                if (target.Contains(lastCharacter))
                {
                    if (characterColor == "Purple") correctPurpleLetters+=1;
                    if (characterColor == "Orange") correctOrangeLetters+=1;
                    if (characterColor == "Yellow") correctYellowLetters+=1;
                    int idx = target.IndexOf(lastCharacter);
                    arr2[idx*3] = lastCharacter;
                    arr_win[idx] = lastCharacter;
                    // GameObject go = GameObject.Find("go" + idx.ToString());
                    // Destroy(go.gameObject);
                }
                else
                {
                    if (characterColor == "Purple") incorrectPurpleLetters+=1;
                    if (characterColor == "Orange") incorrectOrangeLetters+=1;
                    if (characterColor == "Yellow") incorrectYellowLetters+=1;
                    gameObject =
                        Resources
                            .Load("a/red_a_b_" + char.ToLower(lastCharacter)) as
                        GameObject;
                    if (gameObject != null)
                    {
                        print("working");
                    }
                    currentHealth-=5;
                    healthBar.SetHealth (currentHealth);
                    GameObject spawnedLetter = Instantiate(gameObject);
                    spawnedLetter.transform.position = oldPosition;
                    spawnedLetter.transform.localScale = oldscale;
                    Destroy(spawnedLetter, 1);
                }
                wordTMP.text = new string(arr2);

                if (string.Join("", arr_win) == target)
                {
                    StartCoroutine(DataCollection.Upload(1, "SUCCESS"));
                }

                // if (target.Contains(lastCharacter))
                // {
                //     int idx = target.IndexOf(lastCharacter);
                //     arr2[idx] = lastCharacter;
                //     // GameObject go = GameObject.Find("go" + idx.ToString());
                //     // Destroy(go.gameObject);
                // }
                // wordTMP.text = new string(arr2);

                if (string.Join("", arr_win) == target)
                {
                    // Change to next level and so on.
                    win_string = "_____";
                    arr_win = win_string.ToCharArray();

                    // StartCoroutine(SetWinText());
                    StopAllCoroutines();
                    SceneManager.LoadScene("Win");
                    SceneManager.LoadScene("Level 2");
                    // DestroyImmediate(this.gameObject);
                    StartCoroutine(SetWinText());
                    // SceneManager.LoadScene("Win");
                    // SceneManager.LoadScene("Game Over");
                }
            }
            catch (NullReferenceException e)
            {
                Debug.Log (e);
            }
        }

        // If he collects all letters needed and then collides, he moves to next level, else game over. use build index+1
        if (other.gameObject.tag == "FinishLevel" && wordFormed)
        {
            // Game won

            StartCoroutine(DataCollection.Upload(1, "SUCCESS"));
            SceneManager.LoadScene("Game Over");
        }
    }

    IEnumerator SetWinText()
    {
        win_string = "_____";
        arr_win = win_string.ToCharArray();
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Win");
    }
     public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * 10;
        JumpCount -= 1;
    }
}
