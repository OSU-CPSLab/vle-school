using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtShelter1 : MonoBehaviour
{
    public AudioSource tornadoSiren;
    public AudioSource InstructionsCtShelter1; // Change audio
    bool simulationStarted = false;
    public GameObject EmergencyDoorIsOpen;
    public GameObject SimulationON; // So that other scripts can use this as a reference
    public GameObject inShelter;
    bool userHasBeenCongratulated = false;
    public AudioSource congratsAudio;

    IEnumerator GiveInstructions() {
        Debug.Log("Waiting...");
        yield return new WaitForSeconds(5);
        if(simulationStarted == true) {
            Debug.Log("Done waiting!");
            Debug.Log("Audio - ON: InstructionsCtShelter1");
            InstructionsCtShelter1.Play();
        }
    }

    void StartSimulation() {
        Debug.Log("Simulation Started");
        simulationStarted = true;
        SimulationON.SetActive(true);
        Debug.Log("Audio - ON: Tornado Siren");
        tornadoSiren.Play();
        StartCoroutine(GiveInstructions());
    }

    void StopSimulation() {
        Debug.Log("Simulation Ended");
        simulationStarted = false;
        SimulationON.SetActive(false);
        tornadoSiren.Stop();
        InstructionsCtShelter1.Stop();
    }

    void Congratulations() {
        congratsAudio.Play();
        userHasBeenCongratulated = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartSimulation();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            StopSimulation();
        }

        if (inShelter.activeSelf == true && !userHasBeenCongratulated) {
            Congratulations();
        }
    }
}
