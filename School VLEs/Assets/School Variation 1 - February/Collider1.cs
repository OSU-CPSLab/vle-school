using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider1 : MonoBehaviour
{
    Vector3 CameraRigInitialPosition;
    public GameObject CameraRig;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "camera")
        {
            Debug.Log("Collider1: Moving user back to start");
            CameraRig.transform.position = CameraRigInitialPosition;
        }
    }

    private void Start()
    {
        CameraRigInitialPosition = new Vector3(CameraRig.transform.position.x, CameraRig.transform.position.y, CameraRig.transform.position.z);
        this.gameObject.SetActive(false);
    }

    private void Update()
    {

    }
}
