    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using UnityEngine.Networking;

<<<<<<< HEAD
    public class InformationDisplay : MonoBehaviour
=======
public class InformationDisplay : MonoBehaviour
{
    [Header("Information Display Config:")]
    [SerializeField] TextMeshProUGUI infomation;
    [SerializeField] Transform canvasRotationPointPrefab;
    [SerializeField] Transform playerCamera;
    [SerializeField] float distance = 1;
    [SerializeField] float offset = 5;

    private Transform canvasRotationPoint;

    // Start is called before the first frame update
    void Start()
>>>>>>> 309eacf90135a1fa90ba7641bee5027a622c1120
    {
        [Header("Information Display Config:")]
        [SerializeField] TextMeshProUGUI infomation;
        [SerializeField] Transform canvasRotationPointPrefab;
        [SerializeField] Transform playerCamera;
        [SerializeField] float distance = 1;
        [SerializeField] float offset = 5;

<<<<<<< HEAD
        private Transform canvasRotationPoint;
        private Transform canvasRotationPoint2;

        // Start is called before the first frame update
        void Start()
        {
            playerCamera = FindObjectOfType<Camera>().gameObject.transform;
            canvasRotationPoint = Instantiate(canvasRotationPointPrefab, transform);

            // Calculate the position for the second canvasRotationPoint
            Vector3 offsetPosition = -canvasRotationPoint.right * offset;
        }

        IEnumerator GetRequest(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                switch (webRequest.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                        Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                        break;
                }
            }
        }
    
        public void DisplayInformation(string sensorUuid)
        {
            Debug.Log(sensorUuid);
            infomation.text = sensorUuid;
            
            // A correct website page.
            StartCoroutine(GetRequest("http://193.136.194.15:5000/hosts"));


            canvasRotationPoint.position = playerCamera.transform.position + playerCamera.transform.forward * distance;
            canvasRotationPoint.position = new Vector3(canvasRotationPoint.position.x, 1f, canvasRotationPoint.position.z);
            canvasRotationPoint.rotation = new Quaternion(0f, playerCamera.transform.rotation.y, 0f, playerCamera.transform.rotation.w);
            canvasRotationPoint.gameObject.SetActive(true);
        }
    }
=======
        // Calculate the position for the second canvasRotationPoint? No need ig
        Vector3 offsetPosition = -canvasRotationPoint.right * offset;
    }

    public void DisplayInformation(string sensorUuid)
    {
        Debug.Log(sensorUuid);
        infomation.text = sensorUuid;



        canvasRotationPoint.position = playerCamera.transform.position + playerCamera.transform.forward * distance;
        canvasRotationPoint.position = new Vector3(canvasRotationPoint.position.x, 1f, canvasRotationPoint.position.z);
        canvasRotationPoint.rotation = new Quaternion(0f, playerCamera.transform.rotation.y, 0f, playerCamera.transform.rotation.w);
        canvasRotationPoint.gameObject.SetActive(true);

    }
}
>>>>>>> 309eacf90135a1fa90ba7641bee5027a622c1120
