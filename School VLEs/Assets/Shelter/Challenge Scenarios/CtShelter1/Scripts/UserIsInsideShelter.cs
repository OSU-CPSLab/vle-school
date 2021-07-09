using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIsInsideShelter : MonoBehaviour
{
    public GameObject userInsideShlter;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "camera") {
            UserInShelter();
        }
    }

    void UserInShelter() {
        Debug.Log("User is inside shelter");
        userInsideShlter.SetActive(true);
    }
}
