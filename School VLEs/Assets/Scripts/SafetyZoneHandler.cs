using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyZoneHandler : MonoBehaviour {

    bool hasObject = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GameController" && hasObject && !this.GetComponent<AudioSource>().isPlaying) {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag != "GameController") {
            hasObject = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag != "GameController") {
            hasObject = false;
        }
    }
}
