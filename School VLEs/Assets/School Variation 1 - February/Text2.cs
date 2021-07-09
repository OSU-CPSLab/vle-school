using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text2 : MonoBehaviour
{
    public GameObject ArrowTurn;

    private void Awake()
    {
        Debug.Log("Arrow: Activated");
        ArrowTurn.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            Debug.Log("Text2: Deactivated");
            this.gameObject.GetComponentInChildren<Renderer>().enabled = false;
        } 
    }
}
