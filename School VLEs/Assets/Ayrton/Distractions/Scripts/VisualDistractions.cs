using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualDistractions : MonoBehaviour
{
    public GameObject Kids;
    public GameObject Cartoons;
    //Note: Add more Kids inside Kids

    void StartKidsWalkingInOppositeDirection() {
        Debug.Log("Starting Kids Simulation");
        Kids.SetActive(true);
    }

    void StopKidsWalkingInOppositeDirection() {
        Debug.Log("Stopping Kids Simulation");
        Kids.SetActive(false);
    }

    void StartCartoonsWalkingInOppositeDirection() {
        Debug.Log("Starting Kids Simulation");
        Cartoons.SetActive(true);
    }

    void StopCartoonsWalkingInOppositeDirection() {
        Debug.Log("Stopping Kids Simulation");
        Cartoons.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C)) {
            StartKidsWalkingInOppositeDirection();
        }

        if (Input.GetKeyUp(KeyCode.D)) {
            StopKidsWalkingInOppositeDirection();
        }

        if (Input.GetKeyUp(KeyCode.E)) {
            StartCartoonsWalkingInOppositeDirection();
        }

        if (Input.GetKeyUp(KeyCode.F)) {
            StopCartoonsWalkingInOppositeDirection();
        }
    }
}
