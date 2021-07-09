using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsMid2 : MonoBehaviour {

    public GameObject PoliceAvatar;
    bool policeHasTurned = false;

    public GameObject turnedLeftAgain;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PoliceOfficer" && !policeHasTurned) {
            Debug.Log("Policeman is in StairsMid # 2");
            PoliceAvatar.transform.Rotate(0, -90, 0, Space.Self);
            policeHasTurned = true;
            //turnedLeft.SetActive(false);
            turnedLeftAgain.SetActive(true);
        }
    }
    
}
