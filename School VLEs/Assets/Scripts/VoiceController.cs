using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceController : MonoBehaviour {

    public AudioClip[] audioList = new AudioClip[3];
    public bool isFinished = false;
    private int i = 1;

    public Animator avatarAnimator;
    // Use this for initialization
    void Start () {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayDelayed(2f);
	}
	
	// Update is called once per frame
	void Update () {


        /*if (Input.GetKeyUp(KeyCode.UpArrow)) {
            Debug.Log("Up arrow");
            avatarAnimator.SetBool("isTalking", false);
        }*/

        AudioSource audioSource = gameObject.GetComponent<AudioSource>();

        if (audioSource.isPlaying) {
            avatarAnimator.SetBool("isTalking", true);
        }
        if (!audioSource.isPlaying && i < audioList.Length && !isFinished) {
            audioSource.clip = audioList[i];
            avatarAnimator.SetBool("isTalking", true);
            audioSource.PlayDelayed(1f);
            i++;
        }

        if(i >= audioList.Length && !audioSource.isPlaying) {
            avatarAnimator.SetBool("isTalking", false);
            isFinished = true;
        }
    }
}
