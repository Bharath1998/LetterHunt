using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static DataCollection;

public class TutorialScript : MonoBehaviour
{
    public void PlayGame(){
        DataCollection.levelIndicator = 1;
        SceneManager.LoadScene("Level 1");
    }
}
