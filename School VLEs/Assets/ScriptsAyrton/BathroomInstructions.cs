using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomInstructions : MonoBehaviour
{
    public GameObject startSimulation;
    public GameObject basicsButton;
    public GameObject skipButton;
    public GameObject triggerChecker;
    public GameObject whiteBoard;
    public GameObject tutorialHasBeenCompleted;
    public GameObject topTouchPadHasBeenPressed;

    public AudioSource IntroductionAudio;
    public AudioSource ControllerTutorialAudio;
    public AudioSource TutorialCompletedAudio;

    bool IntroductionHasBeenPlayed = false;
    bool BasicsTutorialHasBeenPlayed = false;
    bool handOnBasicsButton = false;
    bool instructionsForTutorialHaveBeenCompleted = false;

    public Animator JoeAnim;

    float holdTrigger = 3.0f;
    float timer = 0.0f;
    int count = -1;

    Vector3 basicsButtonInitialPosition;
    Vector3 basicsButtonPressedPosition;

    float offsetButtonPressed = 0.017f;

    void Start() {
        JoeAnim = JoeAnim.GetComponent<Animator>();
    }

    void Introduction() {
        IntroductionHasBeenPlayed = true;

        basicsButton.SetActive(true);
        basicsButtonInitialPosition = new Vector3(basicsButton.transform.position.x, basicsButton.transform.position.y, basicsButton.transform.position.z);
        basicsButtonPressedPosition = new Vector3(basicsButtonInitialPosition.x - offsetButtonPressed, basicsButtonInitialPosition.y, basicsButtonInitialPosition.z);

        skipButton.SetActive(true);

        IntroductionAudio.Play();
    }

    void BasicsTutorial() {
        BasicsTutorialHasBeenPlayed = true;
        Debug.Log("Playing Basics Tutorial...");
        ControllerTutorialAudio.Play();
        whiteBoard.SetActive(true);
    }

    void TutorialCompleted() {
        TutorialCompletedAudio.Play();
    }

    void OnTriggerEnter(Collider other) {
        handOnBasicsButton = true;
    }

    void OnTriggerExit(Collider other) {
        handOnBasicsButton = false;
    }

    void Update() {
        //Starting Introduction Tutorial
        if (startSimulation.activeSelf == true && IntroductionHasBeenPlayed == false) {
            Debug.Log("Accessing Introduction Audio");
            Introduction();
        }

        // Talking animation when playing Audio
        if(IntroductionAudio.isPlaying || ControllerTutorialAudio.isPlaying) {
            //JoeAnim.Play("TALKING");
            JoeAnim.SetBool("isTalking", true);
        }

        if(TutorialCompletedAudio.isPlaying) {
            //JoeAnim.Play("TALKING2");
            JoeAnim.SetBool("isEnding", true);
        }

        // IDLE animation when not playing any audio
        if (!IntroductionAudio.isPlaying && !ControllerTutorialAudio.isPlaying && !TutorialCompletedAudio.isPlaying) {
            //JoeAnim.Play("IDLE");
            JoeAnim.SetBool("isTalking", false);
        }

        //Starting Basics Tutorial
        if (handOnBasicsButton == true && triggerChecker.activeSelf == true && BasicsTutorialHasBeenPlayed  == false && !IntroductionAudio.isPlaying) {
            Debug.Log("Basics button has been pressed");
            basicsButton.transform.position = basicsButtonPressedPosition;
            BasicsTutorial();
        }

        //Tutorial has been completed
        if (IntroductionHasBeenPlayed == true && BasicsTutorialHasBeenPlayed == true) {
            instructionsForTutorialHaveBeenCompleted = true;
        }

        if (instructionsForTutorialHaveBeenCompleted == true && tutorialHasBeenCompleted.activeSelf == false) {
            //PullingTrigger 3 times
            if(triggerChecker.activeSelf == true) {
                count++;
                Debug.Log("Trigger has been pulled " + count + " times!");
            }

            if(count == 3) {
                Debug.Log("Tutorial has been completed");
                whiteBoard.SetActive(false);
                tutorialHasBeenCompleted.SetActive(true);
                TutorialCompleted();
            }
        }
    }
}
