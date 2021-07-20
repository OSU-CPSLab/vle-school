using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesFalling : MonoBehaviour
{
    Rigidbody rb;
    public float thrust = 2.0f;
    public AudioSource boxFalling;

    //public Rigidbody box1, box2, box3, box4, box5, box6;

    public GameObject Direction;
    bool StartDistraction = false;
    bool boxHasBeenPushed = false;
    float timer, timeBox;



    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        timeBox = Random.Range(2.0f, 20.0f);
    }
    void BoxesSimulation() {
        Debug.Log("Starting Box Simulation");
        StartDistraction = true;
    }

    void PushBox(Rigidbody box) {
        Debug.Log("Pushing " + box + "at " + timer + " seconds");
        box.isKinematic = false;

        if(Direction.tag == "zAxis") {
            boxFalling.PlayDelayed(0.5f);
            box.AddForce(thrust, 0, 0, ForceMode.Impulse);
        }

        if(Direction.tag == "xAxis") {
            boxFalling.PlayDelayed(0.5f);
            box.AddForce(0, 0, -thrust, ForceMode.Impulse);
        }
        //box.AddForce(thrust, 0, 0, ForceMode.Impulse);
        boxHasBeenPushed = true;
    }

    void Update()
    {
        //Note: STARTING SIMULATION WITH SPACE BAR
        if (Input.GetKeyDown(KeyCode.F9)){
            BoxesSimulation();
        }

        if (StartDistraction == true) {
            timer += Time.deltaTime;
        }

        if(timer >= timeBox && !boxHasBeenPushed) {
            PushBox(rb);
        }
    }
}
