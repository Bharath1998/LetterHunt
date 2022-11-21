using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightLetters : MonoBehaviour
{
    public static string targetWord;

    public GameObject letters;

    GameObject highlightedLetter;

    GameObject dullLetter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            targetWord = LetterSpawner.target_word;
            print("TARGET WORD: " + targetWord);
            for (int i = 0; i < targetWord.Length; i++)
            {
                letters =
                    GameObject
                        .Find("yellow_a_b_" +
                        targetWord[i].ToString().ToLower() +
                        "(Clone)");
                if (letters)
                {
                    print("NOTNULL");
                    Vector3 oldPosition = letters.transform.position;
                    Vector3 oldscale = letters.transform.localScale;
                    Destroy (letters);
                    highlightedLetter =
                        Resources
                            .Load("GreenLetters/a/green_a_b_" +
                            char.ToLower(targetWord[i])) as
                        GameObject;
                    GameObject spawnedHighlightedLetter =
                        Instantiate(highlightedLetter);
                    spawnedHighlightedLetter.transform.position = oldPosition;
                    spawnedHighlightedLetter.transform.localScale = oldscale;
                    Destroy(spawnedHighlightedLetter, 3);
                    dullLetter =
                        Resources
                            .Load("YellowLetters/a/yellow_a_b_" +
                            char.ToLower(targetWord[i])) as
                        GameObject;
                    GameObject spawnedDullLetter = Instantiate(dullLetter);
                    spawnedDullLetter.transform.position = oldPosition;
                    spawnedDullLetter.transform.localScale = oldscale;
                    Destroy(this.gameObject);
                }
                else
                {
                    print("NULL");
                }
            }
        }
    }
}
