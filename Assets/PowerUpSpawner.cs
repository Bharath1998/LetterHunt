using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpReference;
    public int[] index = {2, 0, 2, 0, 2, 0};

    public double[,] position = {{28.0,12.0},{24.5,12.76},{11.65,12.85},{-2.97,14.04}, {14.02,10.99},{29.15,5.92},{-7.78,13.1}};
    HashSet<int> used = new HashSet<int>();
    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPowerUp() {
        int i=0;
        while(i < index.Length){
            yield return new WaitForSeconds(10); //change this
            // Random rand = new Random();
            int x = Random.Range(0, 7);
            
            // int x = rand.Next(0,7);
            while(used.Contains(x)){
                x = Random.Range(0, 7);
            }
            used.Add(x);
            double posX = position[x, 0];
            double posY = position[x, 1];
            Vector3 randomPosition = new Vector3((float)posX,(float)posY,0);
            GameObject spawnedPowerUp = Instantiate(powerUpReference[index[i]]);
            i += 1;
            spawnedPowerUp.transform.position = randomPosition; 
        }
    }
}