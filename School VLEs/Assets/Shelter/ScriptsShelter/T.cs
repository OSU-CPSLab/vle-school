using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.tag == "PoliceOfficer") {
            Debug.Log("Police officer touched test colldier");
        }
    }
}
