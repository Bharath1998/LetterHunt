using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public GameObject[] letterReference;

    public GameObject spawnedLetter;
    public Transform leftPos, rightPos;
    private int randomSide;
    private int randomIndex;
    private float randomX;
    private float randomY;
    //private int[] index = {0, 5, 4, 8, 15, 25, 1, 0, 16};
    private int[] index;
    private int i = 0;

    public static string target_word;
    private int[] blanks;
    private string[] letters;

    public TextAsset textJSON;

    [System.Serializable]
    public class Player
    {
        public string target_word;
        public int[] blanks;
        public string[] letters;
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
        foreach (Player player in myPlayerList.lvl1)
        {
            if(i==rInt){
                target_word = player.target_word;
                blanks = player.blanks;
                letters = player.letters;
            }
            i++;
            
        }
        index = new int[letters.Length];
        for(int j=0; j<letters.Length; j++)
        {
            int ascii = (int)letters[j][0];
            ascii = ascii - 65;
            index[j] = ascii;
            //print(index[j]);
        }
        print("Word is ="+target_word);
        StartCoroutine(SpawnLetters());
    }

    IEnumerator SpawnLetters() {

        while(i < index.Length){
            if(i!=0){
                yield return new WaitForSeconds(1);
            } 
            randomIndex = Random.Range(0, letterReference.Length);
            
            float x = Random.Range(-7,30);
            float y = Random.Range(0,16);
            Vector3 randomPosition = new Vector3(x,y,0);
            while(true){
                if( (x >= -8.5 && x <= -3 && y >=0 && y<=4.5) ||
                (x >= -8.5 && x <= -0.5 && y >=7 && y<=11) ||
                (x >= -8.5 && x <= 31 && y >=15 && y<=18) ||
                (x >= 1.5 && x <= 11.5 && y >=0 && y<=4) ||
                (x >= 10 && x <= 20 && y >= 2.5 && y<=9) ||
                (x >= 20 && x <= 30 && y >= 1.5 && y<=4)){
                    randomPosition = new Vector3(x,y,0);
                    break;
                }else{
                    x = Random.Range(-7,30);
                    y = Random.Range(0,16);
                }
            }
            if(i==0){
                randomPosition = new Vector3((float)-5.5,(float)-0.25,0);
            }
            spawnedLetter = Instantiate(letterReference[index[i]]);
            i += 1;
            spawnedLetter.transform.position = randomPosition;          
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
