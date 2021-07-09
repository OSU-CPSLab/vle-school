using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyDoor : MonoBehaviour
{
    //Attach this script to the pressable bar of the emergency door
    public GameObject SimulationOn;
    Animator barAnim;
    Animator doorAnim;
    public AudioSource doorOpeningEffect;
    public GameObject Door;
    bool doorIsOpened = false;

    private void OnTriggerEnter(Collider other) {
        //Only allowing user to open door if simulation is on and if it tries to open the door
        if (other.tag == "GameController" && SimulationOn.activeSelf == true && !doorIsOpened) {
            OpenDoor();
        }
    }

    void OpenDoor() {
        Debug.Log("Opening Door");
        doorIsOpened = true;
        barAnim.SetBool("isPressed", true);
        doorOpeningEffect.Play();
        doorAnim.SetBool("isOpening", true);
    }

    private void Start() {
        barAnim = this.GetComponent<Animator>();
        doorAnim = Door.GetComponent<Animator>();
    }

    private void Update() {
        //Just for testing purposes
        if (Input.GetKeyDown(KeyCode.DownArrow) && SimulationOn.activeSelf == true && !doorIsOpened) {
            OpenDoor();
        }
    }
}
