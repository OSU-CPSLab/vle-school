using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2A_Door_InitialRoom : MonoBehaviour
{
    Animator handleBarAnim;
    bool firstTime = true;
    public AudioSource doorOpeningSound;
    //public GameObject door;
    public Animator doorAnim;

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
    }

    private void Update()
    {
        if (handleBarAnim.GetCurrentAnimatorStateInfo(0).IsName("isOpened"))
        {
            doorAnim.SetBool("isOpening", true);
        }
    }

}
