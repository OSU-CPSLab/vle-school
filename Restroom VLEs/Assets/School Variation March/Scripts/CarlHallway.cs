using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarlHallway : MonoBehaviour
{
    Animator carlHallway;
    AudioSource carlHallwayVoice;
    bool inHallway = false;
    bool coroutineIsOn = false;

    private void Awake()
    {
        carlHallway = this.GetComponent<Animator>();
        carlHallwayVoice = this.GetComponent<AudioSource>();
        inHallway = true;
    }

    IEnumerator coroutineInstructions()
    {
        coroutineIsOn = true;
        yield return new WaitForSeconds(9);
        Debug.Log("Playing Instructions in Hallway");
        carlHallwayVoice.Play();
        coroutineIsOn = false;
    }

    private void Update()
    {
        if (carlHallwayVoice.isPlaying)
        {
            carlHallway.SetBool("isTalking", true);
        }

        if (!carlHallwayVoice.isPlaying)
        {
            carlHallway.SetBool("isTalking", false);
        }
        while (inHallway && !coroutineIsOn)
        {
            StartCoroutine(coroutineInstructions());
        }

    }
}
