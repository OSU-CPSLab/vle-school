using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HandleSnapping : MonoBehaviour {

    public bool isCompleted = false;
    private bool isSoundDone = true;
    private GameObject vm;
    public GameObject nextSnap;
    private Transform ourTrans;
    Animator avatarAnim;
    GameObject Avatar;

	void Start () {
        vm = GameObject.Find("VoiceManager");
        //avatarAnim = GameObject.Find("Avatar");
        Avatar = GameObject.Find("Avatar");
        avatarAnim = Avatar.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        avatarAnim.SetBool("isTalking", false);
        if (!vm.GetComponent<VoiceController>().isFinished){
            avatarAnim.SetBool("isTalking", true);
        }

        if (isSoundDone && this.GetComponent<AudioSource>() && vm.GetComponent<VoiceController>().isFinished) {
            this.GetComponent<AudioSource>().PlayDelayed(1f);
            //Arty
            //Debug.Log("Currently playing: " + this.GetComponent<AudioSource>());
            
            //End Arty
            isSoundDone = false;
        }

        if (this.GetComponent<AudioSource>().isPlaying){
            avatarAnim.SetBool("isTalking", true);
        }

        if (this.GetComponent<AudioSource>().isPlaying == false){
            avatarAnim.SetBool("isTalking", false);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == this.tag) {

            nextSnap.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
