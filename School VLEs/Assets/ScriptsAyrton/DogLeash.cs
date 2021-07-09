using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLeash : MonoBehaviour
{
    public GameObject UserHasDogLeashInHand; //Activator
    public GameObject UserDoesNotHaveLeashInHand;
    public GameObject Trigger;
    bool grabbedLeash = false;

    void OnTriggerEnter(Collider other) {
        Debug.Log("User entered handle of leash");
        UserDoesNotHaveLeashInHand.SetActive(false);
        grabbedLeash = true;
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("Solto leash");
        grabbedLeash = false;
        UserHasDogLeashInHand.SetActive(false);
        UserDoesNotHaveLeashInHand.SetActive(true);
    }

    private void Update() {
        if(grabbedLeash == true) {
            Debug.Log("User has leash In Hand");
            UserHasDogLeashInHand.SetActive(true);
        }
    }
}
