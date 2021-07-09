using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid1Walking : MonoBehaviour
{
    Animator kidAnim;
    Vector3 initialPosition;
    int kidTurned = 0;
    float speed = 1.3f;

    void Awake() {
        initialPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        kidAnim = this.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Kid 1 collided with " + other);

        if(other.tag == "TurnLeft") {
            kidAnim.SetBool("isTurning", true);
        }
        // 01/23/21 - Fixing rotation of visual distractions - kids walking in the oppsoite direction
        //Commented out the code below
        /*
        if(other.tag == "TurnLeft") {
            transform.Rotate(0, -90, 0);
            kidTurned += 1;
        }

        if (other.tag == "TurnLeft2") {
            transform.Rotate(0, -90, 0);
            kidTurned += 1;
        }

        if(other.tag == "EndOfHallway") {
            transform.position = initialPosition;
            transform.Rotate(0, 180, 0);
            kidTurned = 0;
        }
        */
    }

    void Update()
    {
        if (kidAnim.GetCurrentAnimatorStateInfo(0).IsName("Walking")) {
            if(kidTurned == 0) {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
            if(kidTurned == 1) {
                transform.position += Vector3.forward * Time.deltaTime * speed;
            }
            if(kidTurned == 2) {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
    }
}
