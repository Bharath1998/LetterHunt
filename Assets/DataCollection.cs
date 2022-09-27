using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class DataCollection
{
    public static IEnumerator Upload(int level = 1, string reasonEnd = "KILLED")
    {
        Debug.Log(reasonEnd);
        DatabaseModel data = new DatabaseModel();
        data.level = level;
        data.reason_end = reasonEnd;
        Debug.Log("DC");

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
            // request.SendWebRequest();

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
