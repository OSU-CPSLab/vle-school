using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Exit_InitialRoom_KidsWalkingInOppositeDirection : MonoBehaviour
{
    public GameObject KidsWalkingInOppositeDirection;

    //Activate kids walking in opposite direction when user exits initial room
    private void OnTriggerEnter(Collider other)
    { 
        if(other.tag == "camera")
        {
            KidsWalkingInOppositeDirection.SetActive(true);
        }
    }
}
