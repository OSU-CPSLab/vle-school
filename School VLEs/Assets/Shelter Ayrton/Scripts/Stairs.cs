using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    bool isOnStairs = false;
    //Attach this script to the collider - Stairs Top
    void OnTriggerEnter(Collider other) {
        if(other.tag == "PoliceOfficer") {
            isOnStairs = true;
        }
    }

    void WalkDown() {

    }

    void Update() {
        if (/*PoliceOfficer*/ isOnStairs){
            WalkDown();
        }
    }
}
