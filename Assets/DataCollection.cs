using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

using static ShootScript;
using static EnemyControl;

public class DataCollection
{
    // [SerializeField]
    // public static ShootScript shootScript;
    public static IEnumerator Upload(int level = 1, string reasonEnd = "KILLED")
    {
        DatabaseModel data = new DatabaseModel();
        data.level = level;
        data.reason_end = reasonEnd;
        data.enemies_killed = EnemyControl.enemiesKilled;
        data.total_bullets = ShootScript.totalBullets;
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

            if (
                request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError
            )
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
            yield return null;
        }
    }
}
