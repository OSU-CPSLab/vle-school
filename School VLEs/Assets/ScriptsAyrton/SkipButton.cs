using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public GameObject skipButton;
    public GameObject triggerChecker;
    public GameObject tutorialHasBeenCompleted;
    public GameObject skipText;
    public GameObject basicsText;

    float timer = 0.0f;
    float TurnOffButtons = 5.0f;

    bool coordinatesHaveBeenStored = false;
    bool handOnSkipButton = false;

    float offsetButtonPressed = 0.017f;

    Vector3 skipButtonInitialPosition;
    Vector3 skipButtonPressedPosition;

    void Start()
    {
        
    }

    void storeCoordinates() {
        skipButtonInitialPosition = new Vector3(skipButton.transform.position.x, skipButton.transform.position.y, skipButton.transform.position.z);
        skipButtonPressedPosition = new Vector3(skipButtonInitialPosition.x - offsetButtonPressed, skipButtonInitialPosition.y, skipButtonInitialPosition.z);
        coordinatesHaveBeenStored = true;
    }

    void OnTriggerEnter(Collider other) {
        handOnSkipButton = true;
    }

    void OnTriggerExit(Collider other) {
        handOnSkipButton = false;
    }

    void SkipTutorial() {
        Debug.Log("Skip Button has been pressed... Skipping Tutorial!");
        skipButton.transform.position = skipButtonPressedPosition;
        tutorialHasBeenCompleted.SetActive(true);
    }

    void Update()
    {
        if(skipButton.activeSelf == true && coordinatesHaveBeenStored == false) {
            storeCoordinates();
        }

        if(handOnSkipButton == true && triggerChecker.activeSelf == true) {
            SkipTutorial();
        }

        if(tutorialHasBeenCompleted.activeSelf == true) {
            timer += Time.deltaTime;
        }

        if (timer >= TurnOffButtons) {
            skipText.SetActive(false);
            basicsText.SetActive(false);
        }
    }
}
