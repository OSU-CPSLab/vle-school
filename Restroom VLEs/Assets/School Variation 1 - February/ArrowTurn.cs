using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTurn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            Debug.Log("Arrow: Deactivated");
            this.gameObject.SetActive(false);
        }
    }
}
