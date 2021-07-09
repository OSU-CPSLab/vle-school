using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject startButton; //Add startButton
    public GameObject startSimulation;// Add startSimulation
    public GameObject triggerChecker;// Add HELP

    public GameObject basicsButtonOff;
    public GameObject skipButtonOff;
    public GameObject TutorialHasBeenCompleted;

    bool handOnButton = false;
    float buttonPressedOffset = -0.016f;
    int count = 0;

    Collider buttonCollider;

    Vector3 buttonInitialPosition;
    Vector3 buttonPressedPosition;
    // Start is called before the first frame update
    void Start() {

        buttonCollider = GetComponent<Collider>();
        buttonInitialPosition = new Vector3(startButton.transform.position.x, startButton.transform.position.y, startButton.transform.position.z);
        buttonPressedPosition = new Vector3(buttonInitialPosition.x + buttonPressedOffset , buttonInitialPosition.y, buttonInitialPosition.z);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other + "On Start Button");
        handOnButton = true;
    }

    void OnTriggerExit(Collider other) {
        Debug.Log(other + " exit ");
        handOnButton = false;
    }

    void ActivateButtons() {
        basicsButtonOff.SetActive(false);
        skipButtonOff.SetActive(false);
    }

    void pressButton() {
        Debug.Log("Button has beed pressed.. Starting simulation...");
        startButton.transform.position = buttonPressedPosition;

        //Connecting scripts by activating the startSimulation cube
        startSimulation.SetActive(true);

    }

    void Update()
    {
        if(handOnButton == true && triggerChecker.activeSelf == true  && count == 0) {
            ActivateButtons();
            pressButton();
            count++;
        }

        if(TutorialHasBeenCompleted.activeSelf == true) {
            startButton.transform.position = buttonInitialPosition;
        }
    }
}
