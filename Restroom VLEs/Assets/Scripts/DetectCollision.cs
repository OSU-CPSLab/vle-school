using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

    public bool isLocked = false;
    private Transform originalParent;
    public GameObject realObject;

    public HandleSnappingObject hso;

    // Use this for initialization
    void Start () {
        originalParent = gameObject.transform.parent;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Detect");
        Debug.Log("Current: " + gameObject + " Colliding with " + other.gameObject);
        Debug.Log("This tag: " + this.tag + " Colliding with tag: " + other.gameObject.tag);
        if(other.gameObject.tag == this.tag) {
            isLocked = true;
            hso.SendMessage("NextObject");
            Destroy(other.gameObject);
            realObject.SetActive(true);
            Destroy(this.gameObject);


            //gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //Destroy(GetComponent<Rigidbody>());
            //gameObject.transform.rotation = other.gameObject.transform.rotation;
            //gameObject.transform.SetParent(originalParent);
            //gameObject.GetComponent<Animator>().enabled = true;
            //gameObject.transform.position = other.gameObject.transform.position;
            //gameObject.transform.rotation = other.gameObject.transform.rotation;



            //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //Debug.Log("Current Game Object: " + gameObject.transform.position + "Colidding object: " + other.gameObject.transform.position);
            //Vector3 difference = other.gameObject.transform.position - gameObject.transform.position;
            //gameObject.transform.Translate(difference);
            //gameObject.transform.localPosition = other.gameObject.transform.localPosition;
            //gameObject.transform.position = other.gameObject.transform.position;
            //gameObject.transform.rotation = other.gameObject.transform.rotation;
        }
    }
}
