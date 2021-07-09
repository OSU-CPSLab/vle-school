using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsBottom : MonoBehaviour
{
    //Attach this script to Stairs Bottom
    public GameObject finishedWalkingDown;
    public GameObject ShelterDoor;
    Animator doorAnim;
    public AudioSource doorEffect;
    bool policeIsOpeningDoor = false;
    bool soundHasBeenPlayed;
    float timer = 0.0f;
    float waitTime = 2.3f;

    void OnTriggerEnter(Collider other) {
        if(other.tag == "PoliceOfficer") {
            Debug.Log("Police made it to the bottom of the end of the stairs");
            finishedWalkingDown.SetActive(true);
            OpenDoor();
            //doorAnim.SetBool("isOpeningDoor", true);
        }
    }

    void OpenDoor() {
        doorAnim.SetBool("isOpeningDoor", true);
        policeIsOpeningDoor = true;
    }

    void doorSound() {
        doorEffect.Play();
        soundHasBeenPlayed = true;
    }



    void Start() {
        doorAnim = ShelterDoor.GetComponent<Animator>();
    }

    private void Update() {
        if (policeIsOpeningDoor) {
            timer += Time.deltaTime;
            if(timer >= waitTime && !soundHasBeenPlayed) {
                doorSound();
            }
        }
    }
}
