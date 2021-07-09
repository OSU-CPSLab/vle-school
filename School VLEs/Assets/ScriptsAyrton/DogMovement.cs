using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public GameObject DogIdle;
    public GameObject userHasGrabbedLeash;
    public GameObject userDoesNotHaveLeashInHand;
    public Transform target;
    public float speed = 0.7f;
    bool dogReachedTarget = false;
    bool startedWalking = false;
    public AudioSource dogBarking;

    Vector3 randomTarget;
    //int counter = 0;

    public Animator dogAnimator;

    Vector3 targetLocation;

    void Start() {
        dogAnimator= dogAnimator.GetComponent<Animator>();
    }

    void Update()
    {
        randomTarget = new Vector3(Random.Range(4, 18), 0, Random.Range(-6, 3));
        float step = speed * Time.deltaTime;

        targetLocation = new Vector3(target.transform.position.x,DogIdle.transform.position.y, target.transform.position.z);

        if (DogIdle.transform.position.z == target.transform.position.z){
            dogAnimator.SetBool("isIdle", true);
            dogAnimator.SetBool("isWalking", false);
            dogReachedTarget = true;
        }

        else {
            dogReachedTarget = false;
        }

        if (userHasGrabbedLeash.activeSelf == true && !dogReachedTarget) {
            startedWalking = true;
            dogAnimator.SetBool("isWalking", true);
            dogAnimator.SetBool("isIdle", false);
            //dogAnimator.Play("Walk");
            DogIdle.transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
            //dogAnimator.Play("Walk");
            //DogIdle.transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
        }

        if(userDoesNotHaveLeashInHand.activeSelf == true && startedWalking == true && !dogReachedTarget){
            dogAnimator.SetBool("isIdle", true);
            dogAnimator.SetBool("isWalking", false);
            startedWalking = false;
        }

        if(dogReachedTarget == true) {
            target.transform.position = randomTarget;
        }

        if (dogAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle2")){
            Debug.Log("Barking!!!");
            dogBarking.Play();
        }



        else {
            //dogAnimator.Play("Idle");
        }
        //Dog.transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        /*if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("UpArrowDown");
            Dog.transform.position += Vector3.forward * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            Debug.Log("UpArrow has been released");
        }
        */
    }
}
