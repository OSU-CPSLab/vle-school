using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWay_2 : MonoBehaviour
{
    Vector3 CameraRigInitialPosition;
    public GameObject CameraRig;

    public GameObject WrongWay2Text;
    public GameObject Text2;
    public GameObject Arrow2;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "camera")
        {
            Debug.Log("Wrong Way 2! Back to Start");
            CameraRig.transform.position = CameraRigInitialPosition;
            Text2.SetActive(false);
            Arrow2.SetActive(false);
            WrongWay2Text.SetActive(false);
        }
    }

    private void Start()
    {
        CameraRigInitialPosition = new Vector3(CameraRig.transform.position.x, CameraRig.transform.position.y, CameraRig.transform.position.z);
        //this.gameObject.SetActive(false);
    }
}
