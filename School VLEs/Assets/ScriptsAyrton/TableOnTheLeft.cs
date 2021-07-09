using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableOnTheLeft : MonoBehaviour
{
    public GameObject tableOnTheLeft;
    public GameObject walkedToLeftTable; //Connector - .SetActive(false) by default

    void OnTriggerEnter(Collider other) {
        Debug.Log("Task 0: User walked to the table");
        Debug.Log("Problema = " + other);
        walkedToLeftTable.SetActive(true);
    }

    void Update()
    {
        
    }
}
