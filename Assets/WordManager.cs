using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WordManager : MonoBehaviour
{
    
    public TMP_Text wordTMP;
    public static WordManager instance;
    // Start is called before the first frame update
    void Start()
    {
        
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
        string wordtmptext=wordTMP.text;
        char[] arr2=wordtmptext.ToCharArray();
        switch(ch){
            case 'c':   
                        arr2[0]='C';
                        break;
            case 'a':   
                        arr2[1]='A';
                        break;
            case 't':   
                        arr2[2]='T';
                        break;
            default: break;
        }
        
        wordTMP.text=new string(arr2);

    } 
}
