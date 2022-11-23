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
    public static string target_word;
    // public GameObject image;
    
    // [SerializeField] private UnityEngine.UI.Image image = null;

    public Canvas imageCanvas;

    void Start()
    {
        timer=Timer.currentTime;
        
        
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
        target_word = PlayerMovement.target;
        print("TARGET WORD FROM HINTSCRIPT"+target_word);
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
        // newObject.transform.position = new Vector3(-500, 1000, 0);
        // newObject.transform.localScale =  new Vector3(3, 3, 0);
        newObject.transform.SetParent(imageCanvas.transform);
        newObject.transform.position = new Vector3(950, 600, 1000);
        newObject.transform.localScale =  new Vector3(2, 2, 0);
        newObject.AddComponent<Image>();
        newObject.GetComponent<Image>().sprite = Resources.Load<Sprite> ("HintImages/" + target_word);
        Destroy(newObject,3f);
        Destroy(button);
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
