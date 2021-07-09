using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIsBackWithJoe : MonoBehaviour
{
    //Activator
    public GameObject userIsWithJoe;

    void OnTriggerEnter(Collider other) {
        Debug.Log("UserIsInYourRoom");
        userIsWithJoe.SetActive(true);
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("UserLeftYourRoom");
        userIsWithJoe.SetActive(false);
    }
}
