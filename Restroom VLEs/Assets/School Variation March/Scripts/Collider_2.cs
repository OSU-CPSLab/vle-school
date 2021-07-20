using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_2 : MonoBehaviour
{
    public GameObject WrongWayText;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            WrongWayText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "camera")
        {
            WrongWayText.SetActive(false);
        }
    }
}
