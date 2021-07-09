using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsLocation : MonoBehaviour
{
    public Animator policeAnim;
    public Animator DoorStairs;
    public AudioSource instructions;
    bool instructionsWereGiven = false;
    public AudioSource DoorOpening;

    float timer = 0.0f;
    int counter = 0;
    bool isGivingInstructions  = false;
    public float InstructionsTime = 5.0f;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "PoliceOfficer") {
            counter += 1;
        }
        if(other.tag == "PoliceOfficer" && counter == 1) {
            isGivingInstructions = true;
            policeAnim.SetBool("isTalking", true);
            Debug.Log("Police: Giving Instructions");
            giveInstructions();
            
        }
    }

    void OpenDoor() {
        DoorStairs.SetBool("isOpening", true);
        DoorOpening.Play();
    }

    void giveInstructions() {
        instructions.Play();
        instructionsWereGiven = true;
    }

    void Update() {
        if(isGivingInstructions){

            if (!instructions.isPlaying && instructionsWereGiven) {
                Debug.Log("Not Playing Instructions");
                policeAnim.SetBool("isTalking", false);
                isGivingInstructions = false;
                //DoorStairs.SetBool("isOpening", true);
                OpenDoor();
                Destroy(this);
            }
            /*timer += Time.deltaTime;
            if(timer >= InstructionsTime) {
                policeAnim.SetBool("isTalking", false);
                isGivingInstructions = false;
                DoorStairs.SetBool("isOpening", true);
            }
            */
        }
    }
}
