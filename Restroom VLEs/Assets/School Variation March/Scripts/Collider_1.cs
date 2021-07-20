using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_1 : MonoBehaviour
{
    Vector3 CameraRigInitialPosition;
    public GameObject CameraRig;

    public GameObject Arrow1;
    public GameObject Text1;

    public GameObject flashingLight1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            Debug.Log("Collider1: Moving user back to start");
            CameraRig.transform.position = CameraRigInitialPosition;
            Arrow1.SetActive(false);
            Text1.SetActive(false);
            flashingLight1.SetActive(false);
        }
    }

    private void Start()
    {
        CameraRigInitialPosition = new Vector3(CameraRig.transform.position.x, CameraRig.transform.position.y, CameraRig.transform.position.z);
    }

    private void Update()
    {

    }
}