using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

using static EnemyControl;
using static PlayerMovement;
using static ShootScript;
using static Timer;

public class DataCollection
{
    public static int levelIndicator = 1;

    public static IEnumerator Upload(string reasonEnd = "KILLED")
    {
        // Abort analytics if env is local
// #if UNITY_EDITOR
//         Debug.Log("score");
//         Debug.Log(PlayerMovement.score);
//         yield return new WaitForSeconds(1);
// #endif
        DatabaseModel data = new DatabaseModel();
        data.level = levelIndicator;
        data.reason_end = reasonEnd;
        data.enemies_killed = EnemyControl.enemiesKilled;
        data.total_bullets = ShootScript.totalBullets;
        data.final_health =
            PlayerMovement.currentHealth > -1
                ? PlayerMovement.currentHealth
                : 0;
        data.time_remaining = (int) Mathf.Round(Timer.currentTime);
        data.correct_orange_letters = PlayerMovement.correctOrangeLetters;
        data.correct_purple_letters = PlayerMovement.correctPurpleLetters;
        data.correct_yellow_letters = PlayerMovement.correctYellowLetters;
        data.incorrect_orange_letters = PlayerMovement.incorrectOrangeLetters;
        data.incorrect_purple_letters = PlayerMovement.incorrectPurpleLetters;
        data.incorrect_yellow_letters = PlayerMovement.incorrectYellowLetters;
        data.score = PlayerMovement.score;
        PlayerMovement.correctYellowLetters = 0;
        PlayerMovement.correctPurpleLetters = 0;
        PlayerMovement.correctOrangeLetters = 0;
        PlayerMovement.incorrectOrangeLetters = 0;
        PlayerMovement.incorrectYellowLetters = 0;
        PlayerMovement.incorrectPurpleLetters = 0;
        EnemyControl.enemiesKilled = 0;
        ShootScript.totalBullets = 0;
        var url =
            "https://data.mongodb-api.com/app/data-sirhi/endpoint/get_entry";
        var json = data.Stringify();
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler =
                (UploadHandler) new UploadHandlerRaw(bodyRaw);

            request.downloadHandler =
                (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SendWebRequest();
            yield return new WaitForSeconds(3);
        }
    }
}
