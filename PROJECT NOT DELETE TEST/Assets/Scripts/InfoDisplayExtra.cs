using Newtonsoft.Json;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class InfoDisplayExtra : MonoBehaviour
{
    public class Data
    {
        public string Humidity     { get; set; }
        public string Pressure     { get; set; }
        public string Temperature  { get; set; }
    }

    public class hostsData
    {
        public string uuidsensor   { get; set; }
        public string materialName { get; set; }
        public string name         { get; set; }
    }

    public TextMeshProUGUI humidityText;
    public TextMeshProUGUI pressureText;
    public TextMeshProUGUI temperatureText;

    public TextMeshProUGUI uuidsensorText;
    public TextMeshProUGUI materialNameText;
    public TextMeshProUGUI nameText;

    void Start()
    {
        StartCoroutine(GetRequest("http://193.136.194.15:5000/GetData/Klfb64a6c72b0e7e"));
        StartCoroutine(GetRequest("http://193.136.194.15:5000/GetData/hosts"));
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
                    break;
                case UnityWebRequest.Result.Success:
                    Data data = JsonConvert.DeserializeObject<Data>(webRequest.downloadHandler.text);
                    hostsData Hostdata = JsonConvert.DeserializeObject<hostsData>(webRequest.downloadHandler.text);



                    humidityText.text = data.Humidity;
                    pressureText.text = data.Pressure;
                    temperatureText.text = data.Temperature;

                    uuidsensorText.text = Hostdata.uuidsensor;
                    materialNameText.text = Hostdata.materialName;
                    nameText.text = Hostdata.name;


                    
                    break;
            }
        }
    }
}
