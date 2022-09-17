using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WordManager : MonoBehaviour
{
    public Text word;
    public TMP_Text wordTMP;
    public static WordManager instance;
    // Start is called before the first frame update
    void Start()
    {
        word.text="___";
        wordTMP.text="___";
    }

    void Awake(){
        instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateWord(char ch){
        // Debug.Log("Received= ", ch);
        string wordtext=word.text;
        string wordtmptext=wordTMP.text;
        char[] arr=wordtext.ToCharArray();
        char[] arr2=wordtmptext.ToCharArray();
        switch(ch){
            case 'c':   arr[0]='C';
                        arr2[0]='C';
                        break;
            case 'a':   arr[1]='A';
                        arr2[1]='A';
                        break;
            case 't':   arr[2]='T';
                        arr2[2]='T';
                        break;
            default: break;
        }

        word.text=new string(arr);
        wordTMP.text=new string(arr2);

    } 
}
