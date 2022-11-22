using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintScript : MonoBehaviour
{
    // Start is called before the first frame update
    // private GameObject image;
    public static float timer;
    public GameObject button;
    public GameObject image;
    public static string target_word;
    // [SerializeField] private UnityEngine.UI.Image image = null;
    void Start()
    {
        timer=Timer.currentTime;
        
        target_word = "MAN";
        image.SetActive(false);
        button.SetActive(false);
    }

    
    void Update()
    {

        timer=(int)Timer.currentTime;
        // print("FROM HINT:"+timer);
        if(timer == 30){
            button.SetActive (true);
            
            return;
        }
        
    }

    public void hintOnClick()
    {
        print("Button CLICKED");
        // image.sprite = Resources.Load<Sprite>( "HintImages/" + target_word+".jpg" );
        image = Resources.Load("HintImages/" + target_word+".jpg") as GameObject;
        // if (image != null)
        {
            print("HINT IMAGE ============= working");
        }
        GameObject ins_image = Instantiate(image);
        ins_image.SetActive(true);
        // yield return new WaitForSeconds(3);
        // image.SetActive(false);
        Destroy(ins_image,3f);

    }
}
