using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private float dist;
    public GameObject player;
    private HingeJoint hinge;
    public float num;

    void Start() 
    {
        hinge = this.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist <= num) 
        {
            JointMotor jm = hinge.motor;
            jm.targetVelocity = 50;
            hinge.motor = jm;
        }
    }
}
