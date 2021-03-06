using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCollisionHandler : MonoBehaviour
{
    public GameObject camRig;
    public float speed = 11;

    void OnCollisionEnter(Collision collision) 
    {
        Debug.Log(collision.gameObject.name);
        Vector3 movement = transform.forward * -speed * Time.deltaTime;
        movement.y = 0;
        camRig.transform.Translate(movement);
    }
}
