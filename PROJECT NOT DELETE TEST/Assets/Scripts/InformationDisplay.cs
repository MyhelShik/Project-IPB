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
    private Transform canvasRotationPoint2;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = FindObjectOfType<Camera>().gameObject.transform;
        canvasRotationPoint = Instantiate(canvasRotationPointPrefab, transform);

                    // pos calc
        Vector3 offsetPosition = -canvasRotationPoint.right * offset;
        canvasRotationPoint2 = Instantiate(canvasRotationPointPrefab, transform.position + offsetPosition, transform.rotation);
    }

    public void DisplayInformation(string objectInformation)
    {
        infomation.text = objectInformation;

        canvasRotationPoint.position = playerCamera.transform.position + playerCamera.transform.forward * distance;
        canvasRotationPoint.position = new Vector3(canvasRotationPoint.position.x, 1f, canvasRotationPoint.position.z);
        canvasRotationPoint.rotation = new Quaternion(0f, playerCamera.transform.rotation.y, 0f, playerCamera.transform.rotation.w);
        canvasRotationPoint.gameObject.SetActive(true);

        
        Vector3 offsetPosition = -canvasRotationPoint.right * offset;
        canvasRotationPoint2.position = canvasRotationPoint.position + offsetPosition;
        canvasRotationPoint2.rotation = canvasRotationPoint.rotation;
        canvasRotationPoint2.gameObject.SetActive(true);
    }
}
