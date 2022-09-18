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
    private int[] index = new int[26];
    private int i = 0;

    private string target_word;
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
            yield return new WaitForSeconds(Random.Range(3, 5));
            randomIndex = Random.Range(0, letterReference.Length);
            //randomSide = Random.Range(0,2);
            //randomX = Random.Range(-7, 30);
            //randomY = Random.Range(0, 5);
            Vector2 randomPosition = new Vector2(Random.Range(-7,30), Random.Range(0,5));
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
