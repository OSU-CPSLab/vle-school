using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopOnTable : MonoBehaviour
{
    public GameObject computerIsOnTable;
    public GameObject laptop;

    Vector3 laptopOnTable;
    Vector3 laptopPosition;
    float yOffset = 0.025f;
    

    void OnTriggerEnter(Collider other) {
        Debug.Log("Laptop is with Joe");
        computerIsOnTable.SetActive(true);  
    }
}
