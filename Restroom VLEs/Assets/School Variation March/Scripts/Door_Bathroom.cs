using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Bathroom : MonoBehaviour
{
    Animator handleBarAnim;
    public Animator doorAnim;
    bool firstTime = true;
    AudioSource doorOpeningSound;
    //Attch this script to the handle bar of the bathroom door
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController" && firstTime)
        {
            firstTime = false;
            handleBarAnim.SetBool("isOpening", true);
            doorOpeningSound.Play();
        }
    }

    private void Start()
    {
        handleBarAnim = this.GetComponent<Animator>();
        doorOpeningSound = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(handleBarAnim.GetCurrentAnimatorStateInfo(0).IsName("DoorIsOpened")){
            doorAnim.SetBool("isOpening", true);
        }
    }
}
