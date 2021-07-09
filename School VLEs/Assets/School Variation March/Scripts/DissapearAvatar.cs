using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearAvatar : MonoBehaviour
{
    public GameObject avatarHallway;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "camera")
        {
            avatarHallway.SetActive(false);
        }
    }
}
