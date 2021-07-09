using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterButton : MonoBehaviour
{
    Animator ButtonAnimator;
    public GameObject triggerDetector;
    public GameObject simulationActivator;
    public AudioSource buttonClicked;
    public AudioSource congratsMessage;
    bool congratulateUser = false;
    bool userHasBeenCongratulated = false;

    float timer = 0.0f;

    void Awake() {
        ButtonAnimator = this.GetComponent<Animator>();
    }

    void CongratulationsMessage() {
        Debug.Log("Congratulating User");
        congratsMessage.Play();
        userHasBeenCongratulated = true;
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "GameController") {
            Debug.Log("Button has been pressed");
            buttonClicked.Play();
            ButtonAnimator.SetBool("buttonHasBeenPressed", true);
            simulationActivator.SetActive(true);
            congratulateUser = true;
        }
        //Debug.Log("Button has been pressed");
        //ButtonAnimator.SetBool("buttonHasBeenPressed", true);
    }

    void Update() {
        if (congratulateUser && !userHasBeenCongratulated) {
            timer += Time.deltaTime;
            if(timer >= 1.5f) {
                CongratulationsMessage();
            }
        }
    }
}
