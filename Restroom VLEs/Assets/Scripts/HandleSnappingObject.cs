using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSnappingObject : MonoBehaviour {
    public GameObject[] SnapObject = new GameObject[17];
    private Color[] originalColor = new Color[17];
    private int i = 0;
    private bool isAddedPhysics = false;
    private int pieces;
    // Use this for initialization
    void Start() {
        //Store the original colors
        for(int i = 0; i < originalColor.Length; i++) {
            originalColor[i] = SnapObject[i].GetComponentInChildren<MeshRenderer>().material.color;
        }
        pieces = SnapObject.Length;
    }

    // Update is called once per frame
    void Update() {
        if (i < pieces) {
            /* Set current object to green
             * If snapping action is completed, set it back to original color
             */
            SnapObject[i].GetComponentInChildren<MeshRenderer>().material.color = new Color((float)152 / 255, (float)244 / 255, (float)126 / 255, (float)255 / 255);
            //if (SnapObject[i].activeInHierarchy == false) {
            //    SnapObject[i].GetComponentInChildren<MeshRenderer>().material.color = originalColor[i];
            //    i++;
            //}
        } else if (i >= pieces){
            isAddedPhysics = true;
            GameObject satellite = GameObject.Find("Satellite Real");

            //Add Box Collider
            satellite.GetComponent<BoxCollider>().enabled = true;

            //Add Rigidbody
            satellite.AddComponent<Rigidbody>();
            satellite.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
            satellite.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            satellite.GetComponent<Rigidbody>().useGravity = true;
            satellite.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void NextObject() {
        SnapObject[i].GetComponentInChildren<MeshRenderer>().material.color = originalColor[i];
        i++;
    }

}
