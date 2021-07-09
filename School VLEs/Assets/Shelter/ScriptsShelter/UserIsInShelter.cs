using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIsInShelter : MonoBehaviour
{
    public AudioSource Congratulations;
    public Animator policeAvatar;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GameController") {
            Congratulations.Play();
            policeAvatar.SetBool("isCongratulating", true);
            Debug.Log("Simulation has been completed!");
        }
    }
}
