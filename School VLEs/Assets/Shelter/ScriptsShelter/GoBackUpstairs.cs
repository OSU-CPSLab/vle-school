using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackUpstairs : MonoBehaviour
{
    public GameObject cameraRigDownstairs;
    public GameObject cameraRigUpstairs;
    public AudioSource buttonPressed;

    Vector3 cameraRigInitialPosition;
    Animator buttonAnim;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GameController") {
            buttonAnim.SetBool("isPressed", true);
            buttonPressed.Play();
            StartCoroutine(GoUpstairs());
        }
    }

    IEnumerator GoUpstairs() {
        Debug.Log("Waiting to go Upstairs");
        //Waiting 2 seconds to teleport upstairs
        yield return new WaitForSeconds(2);
        cameraRigUpstairs.transform.position = cameraRigInitialPosition;

        //Switching cameras
        cameraRigDownstairs.SetActive(false);
        cameraRigUpstairs.SetActive(true);
    }

    void Start() {
        //Storing components and coordinates
        cameraRigInitialPosition = new Vector3(cameraRigUpstairs.transform.position.x, cameraRigUpstairs.transform.position.y, cameraRigUpstairs.transform.position.z);
        buttonAnim = this.GetComponent<Animator>();    
    }
}
