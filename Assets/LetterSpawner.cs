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
    private int[] index = {0, 5, 4, 8, 15, 25, 1, 0, 16};
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
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
