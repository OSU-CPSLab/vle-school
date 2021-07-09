using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the handle bar of the restroom door
public class L2A_Restroom_Door : MonoBehaviour
{
    Animator handleBarAnimator;
    public Animator doorAnim;
    public AudioSource doorOpeningSound;
    bool simulationIsOn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
        {
            handleBarAnimator.SetBool("isOpening", true);
            doorOpeningSound.Play();
        }
    }

    void Start()
    {
        handleBarAnimator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if(handleBarAnimator.GetCurrentAnimatorStateInfo(0).IsName("O"))
        {
            Debug.Log("--->");
            doorAnim.SetBool("isOpening", true);
        }
    }
}
