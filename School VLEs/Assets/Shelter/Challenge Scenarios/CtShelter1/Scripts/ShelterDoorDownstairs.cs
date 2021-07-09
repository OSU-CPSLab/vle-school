using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterDoorDownstairs : MonoBehaviour
{
    // Attach this script to the handle bar of the shelter door downstairs
    Animator handleBarAnim;
    Animator shelterDoorAnim;
    public GameObject ShelterDoor;
    bool doorHasBeenOpened = false;
    public AudioSource doorOpeneingEffect;
    public GameObject barReplacement;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GameController" && !doorHasBeenOpened) {
            OpenDoor();
        }
    }

    void OpenDoor() {
        Debug.Log("Opening Door Donwstairs");
        handleBarAnim.SetBool("isOpening", true);
        shelterDoorAnim.SetBool("isOpeningDoor", true);
        doorOpeneingEffect.Play();
        doorHasBeenOpened = true;
    }

    void Start() {
        handleBarAnim = this.GetComponent<Animator>();
        shelterDoorAnim = ShelterDoor.GetComponent<Animator>();
    }

    private void Update() {
        //For testing purposes only
        if (Input.GetKeyDown(KeyCode.A) && !doorHasBeenOpened) {
            OpenDoor();
        }

        if (handleBarAnim.GetCurrentAnimatorStateInfo(0).IsName("Done")) {
            barReplacement.SetActive(true);
            this.gameObject.SetActive(false);          
        }
    }
}
