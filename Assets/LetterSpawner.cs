using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LetterSpawner : MonoBehaviour
{
    public GameObject[] letterReference;
    public GameObject[] highLetterReference;
    public GameObject[] mediumLetterReference;
    public GameObject[] lowLetterReference;
    
    // public GameObject power_up_highlight;

    public GameObject spawnedLetter;
    public Transform leftPos, rightPos;
    private int randomSide;
    private int randomIndex;
    private float randomX;
    private float randomY;
    //private int[] index = {0, 5, 4, 8, 15, 25, 1, 0, 16};
    private int[] orange_index;
    private int[] yellow_index;
    private int[] purple_index;
    private int[] target_index;
    private int i = 0;
    public List<float[]> seenList;

    public static string target_word;
    private int[] blanks;
    private string[] orange_letters;
    private string[] yellow_letters;
    private string[] purple_letters;

    public Collider2D[] colliders;
    public float radius;

    public TextAsset textJSON;

    [System.Serializable]
    public class Player
    {
        public string target_word;
        public int[] blanks;
        public string[] orange_letters;
        public string[] yellow_letters;
        public string[] purple_letters;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] lvl1;
    }

    public PlayerList myPlayerList = new PlayerList();
    // Start is called before the first frame update
    void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
        int len = myPlayerList.lvl1.Length;
        int rInt = Random.Range(0, len);
        int i=0;
        seenList = new List<float[]>();
        radius = 2f;
        foreach (Player player in myPlayerList.lvl1)
        {
            if(i==rInt){
                target_word = player.target_word;
                blanks = player.blanks;
                orange_letters = player.orange_letters;
                yellow_letters = player.yellow_letters;
                purple_letters = player.purple_letters;
            }
            i++;
            
        }
        orange_index = new int[orange_letters.Length];
        yellow_index = new int[yellow_letters.Length];
        purple_index = new int[purple_letters.Length];
        target_index = new int[target_word.Length];
        for(int j=0; j<orange_letters.Length; j++)
        {
            int ascii = (int)orange_letters[j][0];
            ascii = ascii - 65;
            orange_index[j] = ascii;
            //print(index[j]);
        }

        for(int j=0; j<yellow_index.Length; j++)
        {
            int ascii = (int)yellow_letters[j][0];
            ascii = ascii - 65;
            yellow_index[j] = ascii;
            //print(index[j]);
        }

        for(int j=0; j<purple_index.Length; j++)
        {
            int ascii = (int)purple_letters[j][0];
            ascii = ascii - 65;
            purple_index[j] = ascii;
            //print(index[j]);
        }

        for(int j=0; j<target_word.Length; j++){
            int ascii = (int)target_word[j];
            ascii = ascii - 65;
            target_index[j] = ascii;
            //print("tar_index"+target_index[j]);
        }
        print("Word is ="+target_word);
        StartCoroutine(SpawnLetters());
    }

    IEnumerator SpawnLetters() {
        int t=10;
        while(i < orange_index.Length && i<yellow_index.Length && i<purple_index.Length){
            if(i!=0){
                yield return new WaitForSeconds(2);
            } 
            randomIndex = Random.Range(0, letterReference.Length);
            
            float x = Random.Range(-7,30);
            float y = Random.Range(0,16);
            Vector3 randomPosition = new Vector3(x,y,0);
            
            while(true){
                
                if( checkCollision(x,y) && ((x >= -8 && x <= -4 && y >=0 && y<=4) ||
                (x >= -8 && x <= -0.1 && y >=7 && y<=11) ||
                (x >= -8 && x <= 31 && y >=15.7 && y<=17) ||
                (x >= 1.75 && x <= 11 && y >=0 && y<=4) ||
                (x >= 10 && x <= 20 && y >= 2.9 && y<=9) ||
                (x >= 20 && x <= 31 && y >= 1.75 && y<=4))){
                    randomPosition = new Vector3(x,y,0);
                    seenList.Add(new float[2]{x,y});
                    break;

                }else{
                    x = Random.Range(-7,30);
                    y = Random.Range(0,16);
                }

            }

            if(i==0){
                randomPosition = new Vector3((float)-5.5,(float)-0.25,0);
                seenList.Add(new float[2]{-5.5f,-0.25f});
            }
            // if(i==2){
            //     GameObject power_up_highlight_ins = Instantiate(power_up_highlight);
            //     power_up_highlight_ins.transform.position = randomPosition;
            // }
            spawnedLetter = Instantiate(letterReference[orange_index[i]]);           
            spawnedLetter.transform.position = randomPosition;  

            spawnedLetter = Instantiate(letterReference[yellow_index[i]]);           
            spawnedLetter.transform.position = randomPosition; 

            spawnedLetter = Instantiate(letterReference[purple_index[i]]);           
            spawnedLetter.transform.position = randomPosition; 
            // if(!target_index.Contains(index[i])){
            //     //print(index[i]);
            //     Destroy(spawnedLetter.gameObject, t);
            //     t+=10;
            // } 
            i += 1;      
        }

        int o = i;
        int y = i;
        int p = i;
        i=o;
        while(i < orange_index.Length){
            if(i!=0){
                yield return new WaitForSeconds(2);
            } 
            randomIndex = Random.Range(0, letterReference.Length);
            
            float x = Random.Range(-7,30);
            float y = Random.Range(0,16);
            Vector3 randomPosition = new Vector3(x,y,0);
            
            while(true){
                
                if( checkCollision(x,y) && ((x >= -8 && x <= -4 && y >=0 && y<=4) ||
                (x >= -8 && x <= -0.1 && y >=7 && y<=11) ||
                (x >= -8 && x <= 31 && y >=15.7 && y<=17) ||
                (x >= 1.75 && x <= 11 && y >=0 && y<=4) ||
                (x >= 10 && x <= 20 && y >= 2.9 && y<=9) ||
                (x >= 20 && x <= 31 && y >= 1.75 && y<=4))){
                    randomPosition = new Vector3(x,y,0);
                    seenList.Add(new float[2]{x,y});
                    break;

                }else{
                    x = Random.Range(-7,30);
                    y = Random.Range(0,16);
                }

            }

            if(i==0){
                randomPosition = new Vector3((float)-5.5,(float)-0.25,0);
                seenList.Add(new float[2]{-5.5f,-0.25f});
            }
            // if(i==2){
            //     GameObject power_up_highlight_ins = Instantiate(power_up_highlight);
            //     power_up_highlight_ins.transform.position = randomPosition;
            // }
            spawnedLetter = Instantiate(letterReference[orange_index[i]]);
            
            spawnedLetter.transform.position = randomPosition;  
            // if(!target_index.Contains(index[i])){
            //     //print(index[i]);
            //     Destroy(spawnedLetter.gameObject, t);
            //     t+=10;
            // } 
            i += 1;      
        }

        i=y;
        while(i<yellow_index.Length){
            if(i!=0){
                yield return new WaitForSeconds(2);
            } 
            randomIndex = Random.Range(0, letterReference.Length);
            
            float x = Random.Range(-7,30);
            float y = Random.Range(0,16);
            Vector3 randomPosition = new Vector3(x,y,0);
            
            while(true){
                
                if( checkCollision(x,y) && ((x >= -8 && x <= -4 && y >=0 && y<=4) ||
                (x >= -8 && x <= -0.1 && y >=7 && y<=11) ||
                (x >= -8 && x <= 31 && y >=15.7 && y<=17) ||
                (x >= 1.75 && x <= 11 && y >=0 && y<=4) ||
                (x >= 10 && x <= 20 && y >= 2.9 && y<=9) ||
                (x >= 20 && x <= 31 && y >= 1.75 && y<=4))){
                    randomPosition = new Vector3(x,y,0);
                    seenList.Add(new float[2]{x,y});
                    break;

                }else{
                    x = Random.Range(-7,30);
                    y = Random.Range(0,16);
                }

            }

            if(i==0){
                randomPosition = new Vector3((float)-5.5,(float)-0.25,0);
                seenList.Add(new float[2]{-5.5f,-0.25f});
            }
            // if(i==2){
            //     GameObject power_up_highlight_ins = Instantiate(power_up_highlight);
            //     power_up_highlight_ins.transform.position = randomPosition;
            // }
            spawnedLetter = Instantiate(letterReference[yellow_index[i]]);
            
            spawnedLetter.transform.position = randomPosition;  
            // if(!target_index.Contains(index[i])){
            //     //print(index[i]);
            //     Destroy(spawnedLetter.gameObject, t);
            //     t+=10;
            // } 
            i += 1;      
        }
        i=p;
        while(i<purple_index.Length){
            if(i!=0){
                yield return new WaitForSeconds(2);
            } 
            randomIndex = Random.Range(0, letterReference.Length);
            
            float x = Random.Range(-7,30);
            float y = Random.Range(0,16);
            Vector3 randomPosition = new Vector3(x,y,0);
            
            while(true){
                
                if( checkCollision(x,y) && ((x >= -8 && x <= -4 && y >=0 && y<=4) ||
                (x >= -8 && x <= -0.1 && y >=7 && y<=11) ||
                (x >= -8 && x <= 31 && y >=15.7 && y<=17) ||
                (x >= 1.75 && x <= 11 && y >=0 && y<=4) ||
                (x >= 10 && x <= 20 && y >= 2.9 && y<=9) ||
                (x >= 20 && x <= 31 && y >= 1.75 && y<=4))){
                    randomPosition = new Vector3(x,y,0);
                    seenList.Add(new float[2]{x,y});
                    break;

                }else{
                    x = Random.Range(-7,30);
                    y = Random.Range(0,16);
                }

            }

            if(i==0){
                randomPosition = new Vector3((float)-5.5,(float)-0.25,0);
                seenList.Add(new float[2]{-5.5f,-0.25f});
            }
            // if(i==2){
            //     GameObject power_up_highlight_ins = Instantiate(power_up_highlight);
            //     power_up_highlight_ins.transform.position = randomPosition;
            // }
            spawnedLetter = Instantiate(letterReference[purple_index[i]]);
            
            spawnedLetter.transform.position = randomPosition;  
            // if(!target_index.Contains(index[i])){
            //     //print(index[i]);
            //     Destroy(spawnedLetter.gameObject, t);
            //     t+=10;
            // } 
            i += 1;      
        }

    }

    bool checkCollision(float x, float y){
        float left = x - radius;
        float right = x + radius;
        float low = y - radius;
        float high = y + radius;
        for(int j=0;j < seenList.Count; j++){
            float posX = seenList[j][0];
            float posY = seenList[j][1];
            if( posX >= left && posX <= right){
                if(posY >=low && posY <= high){
                    return false;
                }
            }
        }
        return true;

    }
    bool PreventSpawnOverLap(Vector3 spawnPos){
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for(int i=0;i<colliders.Length;i++){
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;
            float left = centerPoint.x-width;
            float right = centerPoint.x+width;
            float lower = centerPoint.y-height;
            float upper = centerPoint.y+height;

            if(spawnPos.x>= left && spawnPos.x <= right){
               if(spawnPos.y >= lower && spawnPos.y <= upper){
                    return false;
               } 
            }
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
