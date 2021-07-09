using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsCollider2 : MonoBehaviour
{
    //Attach this script to the collider - StairsSecondHalf

    bool policeOfficerIsWalkingDown = false;
    public GameObject policeOfficerAvatar;
    float timer = 0.0f;
    public float nextStep = 1.0f; //Drops one step every x time
    Vector3 currPosition;
    Vector3 offset;
    public float drop;
    int totalOfStepsTaken;
    int stairSize = 9;
    public float policeOfficerSpeed = 0.0f;
    Animator policeOfficerAnim;

    bool startingSecondHalf = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "PoliceOfficer") {
            Debug.Log("Police Officer Starting Second Half");
            policeOfficerIsWalkingDown = true;
        }
    }

    private void Start() {
        policeOfficerAnim = policeOfficerAvatar.GetComponent<Animator>();
        offset = new Vector3(0, drop, 0);
    }

    void Update() {
        //Current Position of Avatar
        currPosition = new Vector3(policeOfficerAvatar.transform.position.x, policeOfficerAvatar.transform.position.y, policeOfficerAvatar.transform.position.z);

        // If Police is walking down, take a step every amount of time until is done
        if (policeOfficerIsWalkingDown) {
            timer += Time.deltaTime;
            if (timer >= nextStep) {
                policeOfficerAvatar.transform.position = currPosition + offset;
                timer = 0.0f;
                totalOfStepsTaken++;
            }
        }

        //PoliceMan is done walking down 
        if (totalOfStepsTaken == stairSize) {
            policeOfficerIsWalkingDown = false;
        }
    }
}
