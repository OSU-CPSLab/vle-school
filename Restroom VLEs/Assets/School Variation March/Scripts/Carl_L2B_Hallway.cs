using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carl_L2B_Hallway : MonoBehaviour
{
    Animator carlHallwayAnim;
    public AudioSource ExcellentAudio;

    bool excellentCompleted = false;
    void Awake()
    {
        carlHallwayAnim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!excellentCompleted && !ExcellentAudio.isPlaying)
        {
            excellentCompleted = true;
            carlHallwayAnim.SetBool("introCompleted", true);
        }
    }
}
