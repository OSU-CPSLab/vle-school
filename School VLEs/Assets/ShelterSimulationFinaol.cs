using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterSimulationFinaol : MonoBehaviour
{
    public GameObject EmergencyShelterON;
    public GameObject EmergencyShelterOFF;
    public GameObject policeAvatar;
    public Animator DoorInitialRoom;
    public Animator DoorStairs;
    public GameObject RedLight;

    public GameObject SimulationActivator;

    public Animator PoliceAnimator;
    public AudioSource TornadoSiren;

    float timerSiren = 8.0f;
    public AudioSource HelpAudio;

    Vector3 InitialPosition;

    bool simulationON = false;
    public AudioSource doorEffect_Opening;

    void Start() {
        PoliceAnimator = PoliceAnimator.GetComponent<Animator>();
        InitialPosition = new Vector3(policeAvatar.transform.position.x, policeAvatar.transform.position.y, policeAvatar.transform.position.z);
    }

    void HelpMessage() {
        Debug.Log("Playing help Audio");
        HelpAudio.Play();
    }

    void StartSiren() {
        Debug.Log("Playing Tornado Siren");
        TornadoSiren.Play();
        EmergencyShelterON.SetActive(true);
        EmergencyShelterOFF.SetActive(false);
    }

    void StopSiren() {
        TornadoSiren.Stop();
    }

    void StartSimulation() {
        //Debug.Log("Playing Tornado Warning Alarm");
        //TornadoSiren.Play();
        //EmergencyShelterON.SetActive(true);
        //EmergencyShelterOFF.SetActive(false);
        RedLight.SetActive(true);
        simulationON = true;
        DoorInitialRoom.SetBool("isOpened", true);
        doorEffect_Opening.Play();
        PoliceAnimator.SetBool("simulationStarted", true);
    }

    void StopSimulation() {
        EmergencyShelterON.SetActive(false);
        EmergencyShelterOFF.SetActive(true);
        RedLight.SetActive(false);
        TornadoSiren.Stop();
        simulationON = false;
        DoorInitialRoom.SetBool("isClosed", true);
        policeAvatar.transform.position = InitialPosition;
        PoliceAnimator.Play("WalkingInPlace 0");
        PoliceAnimator.SetBool("simulationStarted", false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Starting Alarm");
            StartSiren();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            Debug.Log("Stopping Simulation");
            StopSiren();
        }

        if(SimulationActivator.activeSelf == true && !simulationON) {
            StartSimulation();
        }

        if (TornadoSiren.isPlaying && !simulationON) {
            timerSiren += Time.deltaTime;
            //Play Audio every 10 seconds until user presses button
            if(timerSiren >= 10.0f) {
                HelpMessage();
                timerSiren = 0.0f;
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Starting Shelter Simulation!");
            StartSimulation();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            Debug.Log("Stopping Simulation");
            StopSimulation();
        }
        */
    }
}
