using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1FoundBathroom : MonoBehaviour {
    public GameObject foundBathroom;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Bathroom has been found");
        foundBathroom.SetActive(true);
    }

    void OnTriggerExit(Collider other) {
        foundBathroom.SetActive(false);
    }
}