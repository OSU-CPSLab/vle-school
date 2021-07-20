using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the GameObjects named Avatar Exhange in colliders
public class L2B_AvatarExhange : MonoBehaviour
{
    public GameObject carlOldPos;
    public GameObject carlNewPos;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "camera")
        {
            carlOldPos.SetActive(false);
            carlNewPos.SetActive(true);
        }
    }
}
