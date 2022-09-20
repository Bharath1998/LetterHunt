using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class KillPlayerScript : MonoBehaviour
{
    public DatabaseModel data;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            StartCoroutine(Upload());
            Destroy (gameObject);
            Camera cam = Camera.main;
            GameObject newCam = new GameObject("newMainCam");
            newCam.AddComponent<Camera>();
            SceneManager.LoadScene("Game Over");
        }
    }

    IEnumerator Upload(System.Action<bool> callback = null)
    {
        data = new DatabaseModel();
        data.name = "Vini Jr.";
        data.age = "22";
        data.position = "Forward";
        Debug.Log("Started 1");
        Debug.Log(data.Stringify());

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
