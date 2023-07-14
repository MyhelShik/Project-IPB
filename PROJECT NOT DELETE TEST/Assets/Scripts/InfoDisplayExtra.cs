using Newtonsoft.Json;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class InfoDisplayExtra : MonoBehaviour
{
    public class Data
    {
        public string Humidity { get; set; }
        public string Pressure { get; set; }
        public string Temperature { get; set; }
    }

    public TextMeshProUGUI humidityText;
    public TextMeshProUGUI pressureText;
    public TextMeshProUGUI temperatureText;

    public float refreshInterval = 5f; // Refresh interval in seconds

    private string uri = "http://193.136.194.15:5000/GetData/Klfb64a6c72b0e7e";
    private bool isRefreshing = false;

    void Start()
    {
        StartCoroutine(RefreshData());
    }

    IEnumerator RefreshData()
    {
        while (true)
        {
            if (!isRefreshing)
            {
                isRefreshing = true;    

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
                            Data data = JsonConvert.DeserializeObject<Data>(webRequest.downloadHandler.text);

                            humidityText.text = data.Humidity;
                            pressureText.text = data.Pressure;
                            temperatureText.text = data.Temperature;

                            break;
                    }
                }

                isRefreshing = false;
            }

            yield return new WaitForSeconds(refreshInterval);
        }
    }
}
