using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to Collider StairsMid
public class StairsMid : MonoBehaviour
{
    public GameObject PoliceAvatar;
    public GameObject turnedLeft; //Activator
    public GameObject turnedLeftAgain; //Activator

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "PoliceOfficer") {
            Debug.Log("Policeman is in StairsMid");
            PoliceAvatar.transform.Rotate(0, -90,0, Space.Self);
            turnedLeft.SetActive(true);
        }
    }

    /*private void OnTriggerExit(Collider other) {
        if (other.tag == "PoliceOfficer") {
            Debug.Log("Policeman is in StairsMid # 2");
            PoliceAvatar.transform.Rotate(0, -90, 0, Space.Self);
            turnedLeft.SetActive(false);
            turnedLeftAgain.SetActive(true);
        }
    }
    */
}
