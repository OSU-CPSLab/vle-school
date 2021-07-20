using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to all the wrong-way colliders of L2A
public class WrongWayColliders : MonoBehaviour
{
    public GameObject cameraRig;
    Vector3 initialPosition;

    private void OnTriggerEnter(Collider other)
    {
        //If headset enters collider, take user back to initial position
        if (other.tag == "camera")
        {
            Debug.Log("Wrong Way Collider: Sending player back to start");
            cameraRig.transform.position = initialPosition;
        }
    }

    private void Start()
    {
        initialPosition = new Vector3(cameraRig.transform.position.x, cameraRig.transform.position.y, cameraRig.transform.position.z);
    }
}
