using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner_level0 : MonoBehaviour
{
    public GameObject[] letterReference;

    public GameObject spawnedLetter;
    public Transform leftPos, rightPos;
    private int randomSide;
    private float randomX;
    private float randomY;
    private int[] index;
    private int i = 0;

    public static string target_word="CAT";


    // Start is called before the first frame update
    void Start()
    {
        char[] letters={'C','Z','A','X','T'};
        index = new int[5];
        for(int j=0; j<5; j++)
        {
            // int ascii = (int)index[j];
            int ascii = letters[j] - 65;
            index[j] = ascii;
        }
        
        print("Word ="+target_word);
        StartCoroutine(SpawnLetters());
    }

    void Update()
    {
        
    }
    IEnumerator SpawnLetters() 
    {

        while(i < index.Length)
        {
            if(i!=0){
                yield return new WaitForSeconds(1);
            }             
            float x = Random.Range(-6,12);
            float y = Random.Range(0,4);
            Vector3 randomPosition = new Vector3(x,y,0);
            if(i==0){
                randomPosition = new Vector3((float)-5.5,(float)-0.25,0);
            }
            spawnedLetter = Instantiate(letterReference[index[i]]);
            i += 1;
            spawnedLetter.transform.position = randomPosition;          
        }
    }
}




