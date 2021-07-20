using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZoneManager : MonoBehaviour {

    public GameObject[] SnapZone = new GameObject[17];
    private int i = 0;
    bool beingHandled = false;

    // Use this for initialization
    void Start () {
		
	}
	
    /*
     * Set current snapping zone active
     * If snapping is completed, move to the next zone
     */
	void Update () {
        if (!beingHandled) {
            StartCoroutine(updateSnapZone());
        }
	}

    IEnumerator updateSnapZone() {
        beingHandled = true;
        yield return new WaitForSeconds(1);
        if (i < SnapZone.Length) {
            SnapZone[i].SetActive(true);
            if (SnapZone[i].GetComponent<AudioSource>()) {
                // ARTY
                if (SnapZone[i].GetComponent<AudioSource>().isPlaying) {
                    Debug.Log("Currently playing " + SnapZone[i]);
                }
                //ARTY
                if (SnapZone[i].GetComponent<HandleSnapping>().isCompleted && !SnapZone[i].GetComponent<AudioSource>().isPlaying) {
                    SnapZone[i].SetActive(false);
                    i++;
                }
            }else if (SnapZone[i].GetComponent<HandleSnapping>().isCompleted) {
                SnapZone[i].SetActive(false);
                i++;
            }
            
        }
        beingHandled = false;
    }
}
