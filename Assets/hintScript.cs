using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hintScript : MonoBehaviour
{
    // Start is called before the first frame update
    // private GameObject image;
    public static float timer;
    public GameObject button;
    // public GameObject image;
    public static string target_word;
    // [SerializeField] private UnityEngine.UI.Image image = null;

    public Canvas imageCanvas;

    void Start()
    {
        timer=Timer.currentTime;
        
        target_word = "MAN";
        // image.SetActive(false);
        button.SetActive(false);

        //find canvas
        GameObject canvasObject = GameObject.Find("ImageCanvas");
        if(canvasObject != null){
            print("CANVAS OBJECT IS NOT NULL");
            //If we found the object , get the Canvas component from it.
            imageCanvas = canvasObject.GetComponent<Canvas>();
            if(imageCanvas == null){
                Debug.Log("Could not locate Canvas component on " + canvasObject.name);
            }
        }
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
        //image = Resources.Load("HintImages/" + target_word+".jpg") as GameObject;
        
        GameObject newObject = new GameObject("hintImage");
        newObject.transform.SetParent(imageCanvas.transform);
        newObject.AddComponent<Image>();
        newObject.GetComponent<Image>().sprite = Resources.Load<Sprite>( "HintImages/" + target_word+".jpg" );
        print("HintImages/" + target_word+".jpg");
        if(Resources.Load("HintImages/" + target_word+".jpg", typeof(Sprite)) as Sprite != null){
            print("IMAGE IS NOT NULL");

        }
        else{
            print("IMAGE IS NULL");
        }


        // if (image != null)
        // {
        //     print("HINT IMAGE ============= working");
        // }
        // GameObject ins_image = Instantiate(image);

        // ins_image.SetActive(true);
        // // yield return new WaitForSeconds(3);
        // // image.SetActive(false);
        // Destroy(ins_image,3f);

    }
}
