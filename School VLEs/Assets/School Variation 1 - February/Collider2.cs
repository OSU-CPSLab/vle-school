using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2 : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Collider1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            Debug.Log("Text1: Activated");
            Text1.SetActive(true);
            this.gameObject.SetActive(false);
            Debug.Log("WrongWay Text: Activated");
            Collider1.SetActive(true);
        }
    }
}
