using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject player;
    private HingeJoint hinge;
    // Start is called before the first frame update
    void Start()
    {
        hinge = this.GetComponent<HingeJoint>();
    }

    public void Open() 
    {
        JointMotor jm = hinge.motor;
        jm.targetVelocity = 50;
        hinge.motor = jm;
    }
}
