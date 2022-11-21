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
    bool canJump=false;
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
    public int MaxJumps = 15; //Maximum amount of jumps (i.e. 2 for double jumps)
    // public static string win_string = "_____";
    // public static char[] arr_win = win_string.ToCharArray();

    public static string win_string;
    public static char[] arr_win;

    public int flag = 0;
    public GameObject youwin;

    void Start()
    {
        Debug.Log("Starting new player movement");
        JumpCount = MaxJumps;
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inventory = new List<string>();
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        correctPurpleLetters=0;
        correctYellowLetters=0;
        correctOrangeLetters=0;
        incorrectPurpleLetters=0;
        incorrectYellowLetters=0;
        incorrectOrangeLetters=0;
        youwin.SetActive(false);
        Time.timeScale = 1f;

        
    }

    // Update is called once per frame
    void Update()
    {

        flag += 1;
        if (flag == 1){
            Scene currentScene = SceneManager.GetActiveScene ();
 
             // Retrieve the name of this scene.
            string sceneName = currentScene.name;


            if (sceneName == "Level 1") 
            {
                target = LetterSpawner.target_word;
            }
            else if (sceneName == "Level 2")
            {
                target = LetterSpawnerLvl2.target_word;
                // print("inside if TARGET FROM PLAYER MOVE "+target);
            }
            else if (sceneName == "Level02-Final") 
            {
              
                target = LetterSpawnerLvl02.target_word;
                print("target printed from player movement : " + target);
            }

            else if (sceneName == "Final_Level2") 
            {
              
                target = LetterSpawnerLvl01.target_word;
                print("target printed from player movement : " + target);
            }

            else if (sceneName == "Level 3") 
            {
              
                target = LetterSpawnerLvl03.target_word;
            }
            else if (sceneName == "Level 6") 
            {
              
                target = LetterSpawnerLvl06.target_word;

                print("target printed from player movement : " + target);
            }
            else if (sceneName == "LevelRO")
            {

                target = Letter_Spawner_Lvl_lro.target_word;

                print("target printed from player movement : " + target);
            }
            else if (sceneName == "lvl9")
            {

                target = LetterSpawnerLvl09.target_word;

                print("target printed from player movement : " + target);
            }

            else if (sceneName == "lvl8")
            {

                target = LetterSpawnerLvl08.target_word;

                print("target printed from player movement : " + target);
            }

            
            print("TARGET FROM PLAYER MOVE : "+target);
            int n = target.Length;
            print("n FROM PLAYER MOVE"+n);
            string pattern = "_  ";
            string temp1 = "_  ";
            for (int i = 0; i < n-2; i++) 
            {
                temp1 = temp1 + pattern;
                
            }
            temp1 = temp1 + "_";

            win_string = new string('_', n);
            arr_win = win_string.ToCharArray();

            wordTMP.text = temp1;
            if (wordTMP.text==null){
                print("NULL");

            }
            else{
                print("DASHES "+wordTMP.text);
            }

        }
        



        movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;
        anim.SetFloat("Speed", Mathf.Abs(movement.magnitude * 3f));
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            float dirX = Input.GetAxisRaw("Horizontal");

            // player.velocity = new Vector2(player.velocity.x, 6);
            if (JumpCount > 0){
                Jump();
            }
        }
        bool flipped = movement.x < 0;
        bool is_still = movement.x == 0;
        if(flipped == true & facingRight == true){
            facingRight = false;
        }
        if(flipped == false & facingRight == false & !is_still){
            facingRight = true;
        }
        this.transform.rotation =
            Quaternion.Euler(new Vector3(0f, !facingRight ? 180f : 0f, 0f));
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

    public void TakeDamage(int x = 0){
    
    if((GameObject.Find("Shield") && GameObject.Find("Shield").activeSelf)==false){
        if (x == 0)
            {
                currentHealth -= damage;
            }
            else
            {
                currentHealth -= x;
            }
        if (currentHealth <= 0)
        {
            StartCoroutine(DataCollection.Upload("KILLED"));
            Destroy(this.gameObject);
            target = null;
            Camera cam = Camera.main;
            GameObject newCam = new GameObject("newMainCam");
            newCam.AddComponent<Camera>();
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            
            healthBar.SetHealth(currentHealth);
        }
    }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name.Contains("Enemy") && (GameObject.Find("Shield") && GameObject.Find("Shield").activeSelf)){
            Destroy(other.gameObject);
        }
         
        if(other.gameObject.tag=="spring"){
            Debug.Log("increase velocity spring");
            player.velocity= new Vector2(player.velocity.x, 15);
        }

        if (other.gameObject.tag == "ground")
        {
            canJump=true;
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

            string characterColor = other.gameObject.GetComponent<CollectableScript>().letterColor;
            // print(characterColor);
            try
            {
                char lastCharacter = characterType[characterType.Length - 1];
                // target = LetterSpawnerLvl2.target_word;
                string wordtmptext = wordTMP.text;
                char[] arr2 = wordtmptext.ToCharArray();

                if (target.Contains(lastCharacter))
                {
                    if (characterColor == "Purple") correctPurpleLetters+=1;
                    if (characterColor == "Orange") correctOrangeLetters+=1;
                    if (characterColor == "Yellow") correctYellowLetters+=1;
                    int idx = target.IndexOf(lastCharacter);
                    arr2[idx*3] = lastCharacter;
                    print("LAST CHARACTER: " + lastCharacter);
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
                    TakeDamage(5);
                    GameObject spawnedLetter = Instantiate(gameObject);
                    spawnedLetter.transform.position = oldPosition;
                    spawnedLetter.transform.localScale = oldscale;
                    Destroy(spawnedLetter, 1);
                }
                wordTMP.text = new string(arr2);

                if (string.Join("", arr_win) == target)
                {
                    // Change to next level and so on.

                    StopAllCoroutines();
                    GamePause();
                    StartCoroutine(DataCollection.Upload("SUCCESS"));
                    Scene currentScene = SceneManager.GetActiveScene();
                    string sceneName = currentScene.name;
                    //You will have to change this --now after winning it should not
                    if (sceneName == "Level02-Final")
                    {
                        youwin.SetActive(true);
                        // StartCoroutine(toLevel2());
                    }
                    else if (sceneName == "Final_Level2"){
                        youwin.SetActive(true);
                        // StartCoroutine(toLevel3());
                    }
                    else if (sceneName == "Level 3"){
                        youwin.SetActive(true);
                        // StartCoroutine(toLevel4());
                    }
                    else if (sceneName == "Level 1"){
                        youwin.SetActive(true);
                        // StartCoroutine(toLevel5());
                    }
                    else if (sceneName == "Level 6"){
                        youwin.SetActive(true);
                        // StartCoroutine(toLevel6());
                    }
                    else if (sceneName == "LevelRO"){
                        youwin.SetActive(true);

                        // StartCoroutine(toLevel7());
                    }
                    else if(sceneName=="lvl9"){
                        youwin.SetActive(true);
                    }
                    else
                    {
                        SceneManager.LoadScene("Win");
                    }
                    // StartCoroutine(SetWinText());

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
            SceneManager.LoadScene("Game Over");
        }
        if (other.gameObject.tag == "platform")
        {
            JumpCount = MaxJumps;
            // Debug.Log("I am on the platform okay");
            this.transform.parent = other.gameObject.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "platform"){
            this.transform.parent = null;
            
        }

        if(other.gameObject.tag=="ground"){
            canJump=false;
        }
        
    }
    IEnumerator SetWinText()
    {
        win_string = "_____";
        arr_win = win_string.ToCharArray();
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("NextLevel");
    }
    IEnumerator toLevel2()
    {
        DataCollection.levelIndicator = 2;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Final_Level2");
    }
    IEnumerator toLevel3()
    {
        DataCollection.levelIndicator = 3;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Level 3");
    }
    IEnumerator toLevel4()
    {
        DataCollection.levelIndicator = 4;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Level 1");
    }
    IEnumerator toLevel5()
    {

        DataCollection.levelIndicator = 5;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Level 6");
    }
    IEnumerator toLevel6()
    {
        DataCollection.levelIndicator = 6;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("LevelRO");
    }
    IEnumerator toLevel7()
    {
        DataCollection.levelIndicator = 7;
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("lvl9");
    }

     public void Jump()
    {
        if(canJump){
            GetComponent<Rigidbody2D>().velocity = transform.up * 9;
            JumpCount -= 1;
            canJump=false;
        }
        
    }

    void GamePause() {
        // pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        // isGamePaused = true;
        // musicGameObject.SetActive(false);
    }
}
