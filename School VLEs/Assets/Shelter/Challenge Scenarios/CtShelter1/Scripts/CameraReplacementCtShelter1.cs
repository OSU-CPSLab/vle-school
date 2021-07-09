using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReplacementCtShelter1 : MonoBehaviour
{

    //Attach this script to the collider at the top of the stairs
    Vector3 fixedLocationCamera;
    public GameObject cameraRig;
    public GameObject cameraReplacement;
    public GameObject cameraRigDownstairs;
    Animator cameraReplacementAnim;
    bool CamerasHaveBeenSwitched;
    public GameObject userIsAtTopOfStairs;
    public GameObject simulationStarted;
    public AudioSource greatJob;
    bool camerasWereSwitchedAgain = false;

    void OnTriggerEnter(Collider other) {
        if(other.tag == "camera" && simulationStarted.activeSelf == true) {
            UserReady();
        }
    }

    void UserReady() {
        userIsAtTopOfStairs.SetActive(true);
    }
    void SwitchCameras() {
        Debug.Log("Switching cameras");
        greatJob.Play();
        fixedLocationCamera = new Vector3(0, 0, 0);
        cameraRig.gameObject.transform.position = fixedLocationCamera;
        cameraRig.gameObject.SetActive(false);
        cameraReplacement.gameObject.SetActive(true);
        cameraReplacementAnim = cameraReplacement.gameObject.GetComponent<Animator>();
        CamerasHaveBeenSwitched = true;
    }

    private void Update() {
        //for testing puroposes
        if (Input.GetKeyDown(KeyCode.LeftArrow) && simulationStarted.activeSelf == true) {
            UserReady();
        }

        if (!CamerasHaveBeenSwitched && userIsAtTopOfStairs.activeSelf == true) {
            SwitchCameras();
        }

        if (cameraReplacementAnim.GetCurrentAnimatorStateInfo(0).IsName("Downstairs") && !camerasWereSwitchedAgain) {
            cameraReplacement.SetActive(false);
            cameraRigDownstairs.SetActive(true);
            camerasWereSwitchedAgain = true;
        }
    }
}
