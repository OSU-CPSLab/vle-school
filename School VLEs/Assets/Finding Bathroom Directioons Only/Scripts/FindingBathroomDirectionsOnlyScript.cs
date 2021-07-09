using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingBathroomDirectionsOnlyScript : MonoBehaviour {
    public AudioSource Task1, GoodJob1, Excellent;
    public Animator AvatarAnim;
    public GameObject TasksColliders, TriggerChecker, FoundBathroom, RightTurn, UserIsInYourRoom, task1Completed;

    bool goodJob1HasBeenPlayed = false;
    bool excellentHasBeenPlayed = false;
    bool simulationHasStarted = false;
    bool simulationHasBeenCompleted = false;
    bool userFoundBathroom = false;
    bool handOnButton = false;

    Animator StartButtonAnim;

    void OnTriggerEnter(Collider other) {
        handOnButton = true;
    }

    private void OnTriggerExit(Collider other) {
        handOnButton = false;
    }

    void StartSimulation() {
        simulationHasStarted = true;
        Debug.Log("Start: Finding Bathroom Directions Only");
        Task1.Play();
        StartButtonAnim.SetBool("buttonPressed", true);
        JoeIsTalking();
        TasksColliders.SetActive(true);
    }

    void JoeIsTalking() {
        AvatarAnim.SetBool("isTalking", true);
    }

    void JoeIsNotTalking() {
        AvatarAnim.SetBool("isTalking", false);
    }
    void UserMadeRighTurn() {
        GoodJob1.Play();
        goodJob1HasBeenPlayed = true;
    }

    void UserFoundBathroom() {
        Excellent.Play();
        excellentHasBeenPlayed = true;
        userFoundBathroom = true;
    }

    void TaskCompleted() {
        Debug.Log("COMPLETED: Bathroom Instructions");
        task1Completed.SetActive(true);
        simulationHasBeenCompleted = true;
    }

    private void Start() {
        StartButtonAnim = this.GetComponent<Animator>();
    }

    void Update() {
        //Start Simulation when pressing Button
        if (!simulationHasStarted && handOnButton && TriggerChecker.activeSelf == true) {
            StartSimulation();
        }

        //On its way
        if(RightTurn.activeSelf == true && !goodJob1HasBeenPlayed) {
            UserMadeRighTurn();
        }

        //Found Bathroom
        if (FoundBathroom.activeSelf == true && !excellentHasBeenPlayed) {
            UserFoundBathroom();
        }

        //Task is done
        if(goodJob1HasBeenPlayed && excellentHasBeenPlayed) {
            TasksColliders.SetActive(false);
        }

        if (userFoundBathroom && UserIsInYourRoom.activeSelf == true && !simulationHasBeenCompleted) {
            TaskCompleted();
        }

        if(simulationHasStarted && !Task1.isPlaying) {
            JoeIsNotTalking();
        }
    }
}
