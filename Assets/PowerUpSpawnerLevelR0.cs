using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerLevelR0 : MonoBehaviour
{
    public GameObject[] powerUpReference;
    public int[] index = {2, 0, 2, 0, 2, 0};
    public GameObject[] spawnRectangles;
    public List<float[]> seenList;
    public float radius;

    void Start()
    {
        radius = 1f;
        seenList = new List<float[]>();
        StartCoroutine(SpawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPowerUp() {
        int i=0;
            
        float x = Random.Range(-7,30);
        float y = Random.Range(0,16);
        Vector3 randomPosition = new Vector3(x,y,0);
        while(i < index.Length){
            yield return new WaitForSeconds(10); //change this

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
            }
            
            
            GameObject spawnedPowerUp = Instantiate(powerUpReference[index[i]]);
            i += 1;
            spawnedPowerUp.transform.position = randomPosition; 
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
}