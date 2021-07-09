using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    //public Vector3 camera;
    //public Transform cameraR;
    //public float YRotation;
    public Transform target;
    float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        // = cameraR.rotation.y;

        if (Input.GetKey(KeyCode.UpArrow)) {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            //this.transform.Rotate(0, YRotation, 0);

            //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            //transform.rotation = Quaternion.LookRotation(newDirection);
            Vector3 targetFloor = new Vector3(target.position.x , 0, target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetFloor, 0.05f);
        }
    }
}
