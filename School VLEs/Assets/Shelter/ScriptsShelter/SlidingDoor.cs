using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Vector3 movementLocation; //the location the door should move to.
    public float slidingSpeed = 10.0f; // the speed that the door will move 

    // Start is called before the first frame update
    void Start()
    {
        movementLocation += transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeginSliding();
        }
    }

    // creates a loop that moves the door closer to is movement location every frame
    private IEnumerator Slide()
    {
        while (Vector3.Distance(transform.position, movementLocation) > 0.01f)
        {
            yield return new WaitForEndOfFrame();

            transform.position =
                Vector3.MoveTowards(transform.position, movementLocation, slidingSpeed);
        }
    }
    
    // a starter class for the Slide coroutine 
    public void BeginSliding()
    {
        StartCoroutine(Slide());
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, movementLocation + transform.position * Time.deltaTime);
    }
}
