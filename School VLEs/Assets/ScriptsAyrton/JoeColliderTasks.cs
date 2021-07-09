using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeColliderTasks : MonoBehaviour
{

    //ScriptAttachedToBackWithJoe
    public GameObject BackWithJoe;
    public GameObject userIsWithJoe; //Checker - Invisible
    public GameObject ballIsWithJoe; // BallChecker (cube trogger inside ball)
    public GameObject computerIsWithJoe; //LapTop Checker
    //public GameObject ballIsBack;

   // public GameObject Ball;


    bool IsWithJoe = false;

    void OnTriggerEnter(Collider other) {
        Debug.Log("User is with Joe!");
        IsWithJoe = true;  

        if(other.gameObject.name == "BallChecker") {
            Debug.Log("Ball is with Joe!");
            ballIsWithJoe.SetActive(true);
        }

        if (other.gameObject.name == "LapTopChecker") {
            Debug.Log("Laptop is with Joe");
            computerIsWithJoe.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("User is NOT with Joe!");
        IsWithJoe = false;
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Object in Area: " + collision);
    }

    void Update() {
        if (IsWithJoe == true) {
            userIsWithJoe.SetActive(true);
        }

        if (IsWithJoe == false) {
            userIsWithJoe.SetActive(false);
        }
    }
}
