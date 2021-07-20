using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHandle : MonoBehaviour
{
    Animator barHandleAnim;
    AudioSource doorOpeningSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
        {
            barHandleAnim.SetBool("isOpening", true);
            doorOpeningSound.Play();
        }
    }

    void Start()
    {
        barHandleAnim = this.GetComponent<Animator>();
        doorOpeningSound = this.GetComponent<AudioSource>();
    }
}
