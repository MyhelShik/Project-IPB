using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    {
        playerCamera = FindObjectOfType<Camera>().gameObject.transform;
        canvasRotationPoint = Instantiate(canvasRotationPointPrefab, transform);

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
