using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the WrongWay Text colliders
public class WrongWayTextColliders : MonoBehaviour
{
    public GameObject wrongWayText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            wrongWayText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "camera")
        {
            wrongWayText.SetActive(false);
        }
    }
}
