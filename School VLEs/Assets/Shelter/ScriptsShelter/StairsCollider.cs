using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsCollider : MonoBehaviour
{
    //Attach this script to the collider - Stairs top

    bool policeOfficerIsWalkingDown = false;
    public GameObject policeOfficerAvatar;
    float timer = 0.0f;
    public float nextStep = 1.0f; // Drops one step every x time
    Vector3 currPosition;
    Vector3 offset;
    public float drop;
    int totalOfStepsTaken;
    int stairSize = 8;
    public float policeOfficerSpeed = 0.0f;
    Animator policeOfficerAnim;
    public GameObject turnedLeft;
    public GameObject turnedLeftAgain;
    public GameObject finishedWalkingDownstairs;
    bool finishedWalking = false;
    float timerAnim = 0.0f;
    public float walkFor = 5.0f;
    bool simulationEnded = false;
    bool AvatarRotationHasBeenFixed = false;
    float Y_offsetAvatar = 0.15f;
    bool startingSecondHalf = false;

    //01/18/21
    public GameObject cameraReplacement;
    public GameObject cameraRig;
    public GameObject cameraRigDownstairs;
    Animator cameraReplacementAnim;
    bool CamerasHaveBeenSwitched = false;
    bool policeHasWaited = false;
    public GameObject userIsReadyToGoDown;
    bool goingDownstairsStart = false;

    public bool currentlyWaiting = false;
    public AudioSource femaleInstructions;
    float timerWait = 4.0f;

    Vector3 fixedLocationCamera;
    bool camerasWereSwitchedAgain = false;
    //End

    void RotateAvatar() {
        AvatarRotationHasBeenFixed = true;
        policeOfficerAvatar.transform.Rotate(0, /*26.39f*/40.39f, 0);
        policeOfficerAvatar.transform.position += new Vector3(0, Y_offsetAvatar, 0);
    }

    void SwitchCameras() {
        //---->
        fixedLocationCamera = new Vector3(0, 0, 0);
        cameraRig.gameObject.transform.position = fixedLocationCamera;
        //---->
        cameraRig.gameObject.SetActive(false);
        cameraReplacement.gameObject.SetActive(true);
        cameraReplacementAnim = cameraReplacement.gameObject.GetComponent<Animator>();
        CamerasHaveBeenSwitched = true;
    }

    void Reminder() {
        Debug.Log("Female Instructions Playing");
        femaleInstructions.Play();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "PoliceOfficer" && !policeHasWaited) {
            Debug.Log("Police Officer is at the top of the stairs");
            currentlyWaiting = true;
            policeOfficerAnim.SetBool("isWaiting", true);
            /*
            policeOfficerIsWalkingDown = true;
            cameraRig.gameObject.SetActive(false);
            cameraReplacement.gameObject.SetActive(true);
            cameraReplacementAnim = cameraReplacement.gameObject.GetComponent<Animator>();
            */
            policeHasWaited = true;
        }

        // 01/18/21
        if(other.tag == "camera") {
            Debug.Log("Tag: " + other.name + " is at: " + this.name);
            //other.gameObject.SetActive(false);

            /*cameraRig.gameObject.SetActive(false);
            cameraReplacement.gameObject.SetActive(true);
            cameraReplacementAnim = cameraReplacement.gameObject.GetComponent<Animator>();
            */
        }
        //End
    }

    private void Start() {
        policeOfficerAnim = policeOfficerAvatar.GetComponent<Animator>();
        offset = new Vector3(0, drop, 0);
    }

    void Update() {
        if (policeOfficerAnim.GetCurrentAnimatorStateInfo(0).IsName("WalkingInPlace") && turnedLeft.activeSelf == false && !startingSecondHalf) {
            policeOfficerAvatar.transform.position += Vector3.right * Time.deltaTime * policeOfficerSpeed;
         }

        if (policeOfficerAnim.GetCurrentAnimatorStateInfo(0).IsName("WalkingInPlace") && turnedLeft.activeSelf == true && !startingSecondHalf) {
            policeOfficerAvatar.transform.position += Vector3.forward * Time.deltaTime * policeOfficerSpeed;
        }

        if (policeOfficerAnim.GetCurrentAnimatorStateInfo(0).IsName("WalkingInPlace") && turnedLeftAgain.activeSelf == true && !finishedWalking) {
            startingSecondHalf = true;
            policeOfficerAvatar.transform.position += Vector3.left * Time.deltaTime * policeOfficerSpeed;
         }

         if (finishedWalkingDownstairs.activeSelf == true) {
            finishedWalking = true;
            policeOfficerAnim.SetBool("isOpeningDoor", true);
         }

        if (policeOfficerAnim.GetCurrentAnimatorStateInfo(0).IsName("WalkingInsideShelter") && !simulationEnded) {
            timerAnim += Time.deltaTime;
            policeOfficerAvatar.transform.position += Vector3.right * Time.deltaTime;
            if (timerAnim >= walkFor) {
                policeOfficerAnim.SetBool("isDone", true);
                simulationEnded = true;
            }

            if (!AvatarRotationHasBeenFixed) {
                RotateAvatar();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || (userIsReadyToGoDown.activeSelf == true && !goingDownstairsStart)) {
            policeOfficerAnim.SetBool("isWaiting", false);
            currentlyWaiting = false;
            goingDownstairsStart = true;
            policeOfficerIsWalkingDown = true;
        }

        //Current Position of Avatar
        currPosition = new Vector3(policeOfficerAvatar.transform.position.x, policeOfficerAvatar.transform.position.y, policeOfficerAvatar.transform.position.z);
        

        // If Police is walking down, take a step every amount of time until is done
       if (policeOfficerIsWalkingDown) {
            if (!CamerasHaveBeenSwitched){
                SwitchCameras();
            }

            timer += Time.deltaTime;
            if(timer >= nextStep) {
                policeOfficerAvatar.transform.position = currPosition + offset;
                Debug.Log(totalOfStepsTaken);
                timer = 0.0f;
                totalOfStepsTaken++;
            }
        }

       //If Policeman is waiting
        if (currentlyWaiting) {
            Debug.Log("Currently waiting...");
            timerWait += Time.deltaTime;
            if (timerWait >= 6.0f) {
                Reminder();
                timerWait = 0.0f;
            }
        }

        //PoliceMan is done walking down 
        if (totalOfStepsTaken == stairSize) {
            policeOfficerIsWalkingDown = false;
        }

        if (cameraReplacementAnim.GetCurrentAnimatorStateInfo(0).IsName("Downstairs") && !camerasWereSwitchedAgain) {
            cameraReplacement.SetActive(false);
            cameraRigDownstairs.SetActive(true);
            camerasWereSwitchedAgain = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SwitchCameras();
        }
    }
}
