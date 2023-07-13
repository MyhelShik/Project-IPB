using Newtonsoft.Json;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class InfoDiplayCanvasInfo : MonoBehaviour
{
    public class HostData
    {
        public string uuidsensor { get; set; }
        public string materialName { get; set; }
        public string name { get; set; }
    }

    public TextMeshProUGUI uuidsensorText;
    public TextMeshProUGUI materialNameText;
    public TextMeshProUGUI nameText;

    void Start()
    {
        StartCoroutine(GetRequest("http://193.136.194.15:5000/hosts"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));
                    // Additional error handling logic or feedback
                    break;
                case UnityWebRequest.Result.Success:
                    HostData[] hostDataArray = JsonConvert.DeserializeObject<HostData[]>(webRequest.downloadHandler.text);
                    if (hostDataArray.Length > 0)
                    {
                        HostData hostData = hostDataArray[0];

                        uuidsensorText.text = hostData.uuidsensor;
                        materialNameText.text = hostData.materialName;
                        nameText.text = hostData.name;
                    }
                    break;
            }
        }
    }
}
