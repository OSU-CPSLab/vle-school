using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script is attached to the interactable GameObject in the Hierarchy
public class ShelterSimulation : MonoBehaviour
{
    public GameObject EmergencyShelterON;
    public GameObject EmergencyShelterOFF;
    public GameObject DoorOutside;
    //public GameObject RoomLights;
    public GameObject RedLight;

    public Animator doorShelterAnim;

    float Xoffset = 0.718f;
    float Zoffset = 0.671f;
    float timer = 0.0f;

    Vector3 DoorOutsideClosed;
    Vector3 DoorOutsideOpened;

    public Animator PoliceAnimator;
    public AudioSource TornadoSiren;

    bool doorIsOpened = false;
    bool simulationStarted = false;

    void Start()
    {
        //OutsideDoor Coordinates
        DoorOutsideClosed = new Vector3(DoorOutside.transform.position.x, DoorOutside.transform.position.y, DoorOutside.transform.position.z);
        DoorOutsideOpened = new Vector3(DoorOutside.transform.position.x + Xoffset, DoorOutside.transform.position.y, DoorOutside.transform.position.z + Zoffset);
        PoliceAnimator = PoliceAnimator.GetComponent<Animator>();
    }

    void OpenDoorOutside() {
        if (!doorIsOpened) {
            DoorOutside.transform.Rotate(0, 100f, 0);
            DoorOutside.transform.position = DoorOutsideOpened;
            doorIsOpened = true;
        }
    }

    void CloseDoorOutside() {
        if (doorIsOpened) {
            DoorOutside.transform.Rotate(0, -100f, 0);
            DoorOutside.transform.position = DoorOutsideClosed;
            doorIsOpened = false;
        }
    }

    void StartSimulation() {
        Debug.Log("Playing Tornado Warning Alarm");
        TornadoSiren.Play();
        EmergencyShelterON.SetActive(true);
        EmergencyShelterOFF.SetActive(false);

        //RoomLights.SetActive(false);
        RedLight.SetActive(true);

        simulationStarted = true;
        OpenDoorOutside();
    }

    void StopSimulation() {
        EmergencyShelterON.SetActive(false);
        EmergencyShelterOFF.SetActive(true);
        RedLight.SetActive(false);
        TornadoSiren.Stop();
        CloseDoorOutside();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Starting Shelter Simulation!");
            StartSimulation();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            Debug.Log("Stopping Simulation");
            StopSimulation();
        }

        if (simulationStarted == true){
            timer += Time.deltaTime;
            if(timer >= 4.0f) {
                //Debug.Log("Policeman starts walking");
                PoliceAnimator.SetBool("isWalking", true);
                PoliceAnimator.SetBool("isIdle", false);
            }

            if(timer >= 5.2f) {
                PoliceAnimator.SetBool("isTurningLeft", true);
                PoliceAnimator.SetBool("isTalking", true);
            }


            if (timer >= 8.5f) {
                //PoliceAnimator.SetBool("isTurningLeft", true);
                PoliceAnimator.SetBool("isTalking", false);
            }
        }

        if (PoliceAnimator.GetCurrentAnimatorStateInfo(0).IsName("Walking 0")) {
            Debug.Log("Opening Door");
            doorShelterAnim.SetBool("isGoingToShelter", true);
        }

        if (Input.GetKey("0")) {
            Debug.Log("0 has been pressed");
            doorShelterAnim.SetBool("isGoingToShelter", true);
        }

        /*
        if (Input.GetKey("left")) {
            PoliceAnimator.SetBool("isWalking", true);
            PoliceAnimator.SetBool("isIdle", false);
        } else {
            PoliceAnimator.SetBool("isWalking", false);
            PoliceAnimator.SetBool("isIdle", true);
        }*/

        /*if (Input.GetKey("0")) {
            PoliceAnimator.SetBool("isTurningLeft", true);
            PoliceAnimator.SetBool("isTalking", true);
        }

        if (Input.GetKey("1")) {
            PoliceAnimator.SetBool("isTalking", true);
        } 
        if (Input.GetKey("2")) {
            PoliceAnimator.SetBool("isTalking", false);
        }
        */


    }
}
