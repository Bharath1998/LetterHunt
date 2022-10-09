using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class EnemyInfo : MonoBehaviour
{
    // Start is called before the first frame update


    public TMP_Text dialogue_instructions;
    //public TMP_Text wordFormed;
    //public string target_word = "CAT";

    GameObject gameObject;
    void Start()
    {
        dialogue_instructions.text = "Enemies deteriorate your health!";

        //wordFormed.text = "___";

        //StartCoroutine(wait());
        callCoroutines();
        
        
        


    }

    // Update is called once per frame
    void Update()
    {

    }

    void callCoroutines()
    {

        //yield return new WaitForSeconds(3f);
        StartCoroutine(wait());
        //StopAllCoroutines();
        //dialogue_instructions.text = "Shoot!";
        
        //StopAllCoroutines();
    }

    
    

    IEnumerator wait()
    {
        print("wait");
        yield return new WaitForSeconds(3f);
        string ins_1 = "Shoot using your mouse";

        StartCoroutine(typeSentence(ins_1));

    }


    // Animator to type sentence

    IEnumerator typeSentence(string sentence)
    {
        dialogue_instructions.text = "";
        foreach (char letter in sentence.ToCharArray())
        {

            print(letter);

            dialogue_instructions.text += letter;
            yield return null;

        }


    }
    public IEnumerator LoadPowerUpTutorial()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);

        // Load Next Scene
        SceneManager.LoadScene("PowerInfo");
    }
}