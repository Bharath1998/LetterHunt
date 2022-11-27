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
    public GameObject[] spawnRectangles;
    
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
    public int[] indexes;
    public int[] colors;

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
        radius = 1f;
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
        int total_length = orange_letters.Length + yellow_letters.Length + purple_letters.Length;
        indexes = new int[total_length];
        colors = new int[total_length];
        int pointer = 0;
        int index_pointer = 0;
        
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

        int max_index = System.Math.Max(orange_letters.Length, System.Math.Max(yellow_letters.Length, purple_letters.Length));
        while(pointer < max_index){
            if(pointer < orange_letters.Length){
                colors[index_pointer] = 1;    
                indexes[index_pointer] = orange_index[pointer];
                index_pointer++;
            }
            if(pointer < yellow_index.Length){
                colors[index_pointer] = 2;
                indexes[index_pointer] = yellow_index[pointer];
                index_pointer++;
            }
            if(pointer < purple_letters.Length ){
                colors[index_pointer] = 3;
                indexes[index_pointer] = purple_index[pointer];
                index_pointer++;
            }
            pointer++;
        }


        print("Word is ="+target_word);
        StartCoroutine(SpawnLetters());
    }

    IEnumerator SpawnLetters() {
        int t=10;
        while(i < indexes.Length){
            if(i!=0){
                yield return new WaitForSeconds(2);
            } 
            randomIndex = Random.Range(0, letterReference.Length);
            
            float x = Random.Range(-7,30);
            float y = Random.Range(0,16);
            Vector3 randomPosition = new Vector3(x,y,0);
            
            while(true){
                int sizeOfSpawners = spawnRectangles.Length;
                x = (float) Random.Range(spawnRectangles[i%sizeOfSpawners].transform.position[0] - spawnRectangles[i % sizeOfSpawners].transform.localScale[0]/2, spawnRectangles[i % sizeOfSpawners].transform.position[0] + spawnRectangles[i % sizeOfSpawners].transform.localScale[0] / 2);
                y = (float)Random.Range(spawnRectangles[i % sizeOfSpawners].transform.position[1] - spawnRectangles[i % sizeOfSpawners].transform.localScale[1] / 2, spawnRectangles[i % sizeOfSpawners].transform.position[1] + spawnRectangles[i % sizeOfSpawners].transform.localScale[1] / 2);


                if (checkCollision(x, y))
                {
                    randomPosition = new Vector3(x, y, 0);
                    seenList.Add(new float[2] { x, y });
                    break;
                }
                
                // if(i % 10 == 0){
                //     x = (float)Random.Range(-8, -4);
                //     y = (float)Random.Range(0, 4);
                // }else if( i % 10 == 1){
                //     x = (float)Random.Range(-8, -0);
                //     y = (float)Random.Range(7, 11);
                // }else if( i % 10 == 3){
                //     x = (float)Random.Range(-8, -4);
                //     y = (float)Random.Range(0, 4);
                // }else if( i % 10 == 2){
                //     x = (float)Random.Range(2, 11);
                //     y = (float)Random.Range(0, 4);
                // }else if( i % 10 == 4){
                //     x = (float)Random.Range(10, 20);
                //     y = (float)Random.Range(3, 9);
                // }else if( i % 10 == 5){
                //     x = (float)Random.Range(20, 31);
                //     y = (float)Random.Range(2, 4);
                // }else if( i % 10 == 7){
                //     x = (float)Random.Range((float)27.56, (float)30.7);
                //     y = (float)Random.Range((float)4.39, (float)10.8);
                // }else if( i % 10 == 6){
                //     x = (float)Random.Range(2, 11);
                //     y = (float)Random.Range(0, 4);
                // }else if( i % 10 == 8){
                //     x = (float)Random.Range(10, 20);
                //     y = (float)Random.Range(3, 9);
                // }else if( i % 10 == 9){
                //     x = (float)Random.Range(20, 31);
                //     y = (float)Random.Range(2, 4);
                // }


                // if(checkCollision(x, y)){
                //     randomPosition = new Vector3(x,y,0);
                //     seenList.Add(new float[2]{x,y});
                //     break;
                // }
                // /*
                // if( checkCollision(x,y) && ((x >= -8 && x <= -4 && y >=0 && y<=4) ||
                // (x >= -8 && x <= -0.1 && y >=7 && y<=11) ||
				// (x >= -8 && x <= -3 && y >=7 && y<=11) ||
                // (x >= -8 && x <= 31 && y >=15 && y<=17) ||
                // (x >= 2 && x <= 11 && y >=0 && y<=4) ||
                // (x >= 10 && x <= 20 && y >= 2.9 && y<=9) ||
                // (x >= 20 && x <= 31 && y >= 1.75 && y<=4))){
                //     randomPosition = new Vector3(x,y,0);
                //     seenList.Add(new float[2]{x,y});
                //     break;

                // }else{
                //     x = Random.Range(-7,30);
                //     y = Random.Range(0,16);
                // }
                // */
            }

            // if(i==0){
            //     x = -1;
            //     y = 4;
            //     randomPosition = new Vector3(x,y,0);
            //     seenList.Add(new float[2]{x,y});
            // }
            int color = colors[i];
            int letter_index = indexes[i];
            /*
            if(i==0){
                randomPosition = new Vector3((float)-5.5,(float)-0.25,0);
                seenList.Add(new float[2]{-5.5f,-0.25f});
            }*/
            // if(i==2){
            //     GameObject power_up_highlight_ins = Instantiate(power_up_highlight);
            //     power_up_highlight_ins.transform.position = randomPosition;
            // }

            int LayerLetter = LayerMask.NameToLayer("Letter");

            if(color == 1){
                spawnedLetter = Instantiate(highLetterReference[letter_index]);           
                spawnedLetter.transform.position = randomPosition;  
                spawnedLetter.layer = LayerLetter;
            }else if(color == 2){
                spawnedLetter = Instantiate(mediumLetterReference[letter_index]);           
                spawnedLetter.transform.position = randomPosition; 
                spawnedLetter.layer = LayerLetter;
            }else{
                spawnedLetter = Instantiate(lowLetterReference[letter_index]);           
                spawnedLetter.transform.position = randomPosition; 
                spawnedLetter.layer = LayerLetter;
            }
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
