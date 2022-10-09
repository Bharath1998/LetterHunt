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
                string ins_1="Correct Letters help you guess the word!";
                StopAllCoroutines();
                StartCoroutine(typeSentence(ins_1));
            }
            if(lastCharacter == 'N'){
                string ins_2="Wrong Letters turn RED!";
                StopAllCoroutines();
                StartCoroutine(typeSentence(ins_2));
            }

            if(lastCharacter == 'D'){
                StartCoroutine(wait());
                string ins_3 = "Press Up Arrow to jump!";
                StopAllCoroutines();
                StartCoroutine(typeSentence(ins_3));
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
                string ins_4 = "Great Going!";
                StopAllCoroutines();
                StartCoroutine(typeSentence(ins_4));
                StartCoroutine(LoadLevel01Tutorial());
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

    // Animator to type sentence
    IEnumerator typeSentence(string sentence){
        dialogue_instructions.text="";
        foreach(char letter in sentence.ToCharArray()){
            dialogue_instructions.text+=letter;
            yield return null;

        }

    }
    IEnumerator LoadLevel01Tutorial () {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("PowerInfo");
    }
}