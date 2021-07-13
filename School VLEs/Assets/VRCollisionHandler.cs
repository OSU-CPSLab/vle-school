using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCollisionHandler : MonoBehaviour
{
    public GameObject camRig;
    public float speed = 300;

    void OnCollisionEnter(Collision collision) 
    {
        Vector3 movement = transform.forward * -speed * Time.deltaTime;
        movement.y = 0;
        camRig.transform.Translate(movement);
    }
}
