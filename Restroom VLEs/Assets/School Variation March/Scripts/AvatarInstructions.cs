using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarInstructions : MonoBehaviour
{
    //Attach this script to game Controller
    public Animator avatarAnim;             //Carl's animator
    public AudioSource avatarInstructions;  //Carl's Instructions
    public GameObject text1;                //Text1
    GameObject avatarInitialRoom;
    public GameObject avatarHallway;

    bool inInitialRoom = true;
    bool coroutineIsOn = false;

    private void Start()
    {
        StartCoroutine(coroutineInstructions());
        avatarInitialRoom = avatarAnim.gameObject;
    }

    IEnumerator coroutineInstructions()
    {
        coroutineIsOn = true;
        yield return new WaitForSeconds(12);
        Debug.Log("Playing Instructions");
        avatarInstructions.Play();
        coroutineIsOn = false;
    }

    private void Update()
    {
        if (text1.activeSelf == true)
        {
            StopCoroutine(coroutineInstructions());
            inInitialRoom = false;
            avatarInitialRoom.SetActive(false);
            avatarHallway.SetActive(true);

            avatarInstructions.gameObject.SetActive(false);
        }

        if (avatarInstructions.isPlaying)
        {
            avatarAnim.SetBool("isTalking", true);
        }

        if (!avatarInstructions.isPlaying)
        {
            avatarAnim.SetBool("isTalking", false);
        }

        while (inInitialRoom && !coroutineIsOn)
        {
            StartCoroutine(coroutineInstructions());
        }
    }
}
