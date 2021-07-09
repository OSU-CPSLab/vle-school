using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1RighTurn : MonoBehaviour
{
    public GameObject correctRightTurn;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Correct Right turn Collider");
        correctRightTurn.SetActive(true);
    }

    void OnTriggerExit(Collider other) {
        correctRightTurn.SetActive(false);
    }
}
