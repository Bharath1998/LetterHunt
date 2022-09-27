using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LetterInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text dialogue_instructions;
    public TMP_Text wordFormed;
    public string target_word="CAT";
    GameObject gameObject;
    void Start()
    {
        dialogue_instructions.text = "Walk over letters to collect them!";
        wordFormed.text="___";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Letter")
        {            
            string characterType = other.gameObject.GetComponent<CollectableScript>().CharacterType;
            Vector3 oldPosition = other.gameObject.transform.position;
            Vector3 oldscale = other.gameObject.transform.localScale;
            Destroy(other.gameObject);
            try
            {
                
            char lastCharacter = characterType[characterType.Length - 1];
            string dialogue_instructionstext=wordFormed.text;
            char[] arr2 = dialogue_instructionstext.ToCharArray();
            if(lastCharacter == 'C'){
                dialogue_instructions.text="Correct Letters help you guess the word!";
            }
            if(lastCharacter == 'N'){
                dialogue_instructions.text="Wrong Letters turn RED!";
            }

            if(lastCharacter == 'D'){
                StartCoroutine(wait());
                dialogue_instructions.text = "Press Up Arrow to jump!";
            }
            if (target_word.Contains(lastCharacter)){
                int idx = target_word.IndexOf(lastCharacter);
                arr2[idx] = lastCharacter;

            }
                else
                {
                    gameObject = Resources.Load("a/red_a_b_" + char.ToLower(lastCharacter)) as GameObject;
                    GameObject spawnedLetter = Instantiate(gameObject);
                    spawnedLetter.transform.position = oldPosition;
                    spawnedLetter.transform.localScale = oldscale;
                    Destroy(spawnedLetter, 1);

                }
            wordFormed.text = new string(arr2);
                
            if(wordFormed.text == target_word){
                dialogue_instructions.text = "Great Going!";
                StartCoroutine(LoadPowerUpTutorial());
            }
            }
            catch (NullReferenceException e)
            {
   
            }
        }
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(1f);
    }
    IEnumerator LoadPowerUpTutorial () {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
        // Load Next Scene
        SceneManager.LoadScene("PowerInfo");
    }
}