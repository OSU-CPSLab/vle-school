using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_3 : MonoBehaviour
{
    public GameObject Arrow1;
    public GameObject Text1;
    public GameObject flashingLigh1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            Arrow1.SetActive(true);
            Text1.SetActive(true);
            flashingLigh1.SetActive(true);
        }
    }
}
