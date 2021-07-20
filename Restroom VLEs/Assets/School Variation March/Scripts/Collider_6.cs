using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_6 : MonoBehaviour
{
    public GameObject Arrow3;
    public GameObject Text3;
    public GameObject flashingLigh2;
    public GameObject flashingLight3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            Arrow3.SetActive(false);
            Text3.SetActive(false);
            flashingLigh2.SetActive(false);
            flashingLight3.SetActive(true);
        }
    }
}
