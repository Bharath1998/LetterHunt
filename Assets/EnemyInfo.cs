using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyInfo : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    public TMP_Text dialogue_instructions;

    GameObject gameObject;

    void Start()
    {
        dialogue_instructions.text = "Enemies deteriorate your health!";
        rb = GetComponent<Rigidbody2D>();
        callCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void callCoroutines()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        string ins_1 = "Shoot using space bar";
        StartCoroutine(typeSentence(ins_1));
    }

    IEnumerator typeSentence(string sentence)
    {
        dialogue_instructions.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue_instructions.text += letter;
            yield return null;
        }
    }

    // void OnCollisionEnter2D(Collision2D collision){
    //     if(collision.gameObject.tag == "Enemy1"){
    //         rb.velocity = Vector2.zero;
    //         rb.isKinematic = true;
    //         Destroy(collision.gameObject);
    //         Destroy(this.gameObject);
    //         StartCoroutine(LoadPowerUpTutorial());
    //     }
    // }
    IEnumerator LoadPowerUpTutorial()
    {
        yield return new WaitForSeconds(2f);

        // Load Next Scene
        SceneManager.LoadScene("PowerInfo");
    }
}
