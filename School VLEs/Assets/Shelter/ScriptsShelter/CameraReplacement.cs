using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReplacement : MonoBehaviour
{
    Vector3 fixedLocation;
    private void Awake() {
        fixedLocation = new Vector3(-4.07f, 0.04f, -2.788f);
        this.transform.position = fixedLocation;
    }
}
