using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carl_L2B_InitialRoom : MonoBehaviour
{

    Animator carlInitialRoomAnim;
    public AudioSource IntroductionAudio;

    bool introductionCompleted = false;
    void Start()
    {
        carlInitialRoomAnim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!introductionCompleted && !IntroductionAudio.isPlaying)
        {
            introductionCompleted = true;
            carlInitialRoomAnim.SetBool("introCompleted", true);
        }
    }

}
