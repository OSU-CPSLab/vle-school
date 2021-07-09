using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour {
    
    // 1
    public GameObject laserPrefab;
    // 2
    private GameObject laser;
    // 3
    private Transform laserTransform;
    // 4
    private Vector3 hitPoint;
    

    void Start() {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;    
    }

    void Update() {

        Debug.Log("HIT HIT HIT");
        RaycastHit hit;
        //Debug.Log(Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100));
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity)) {
            Debug.Log("INSIDE RAY CAST");
            hitPoint = hit.point;
            ShowLaser(hit);
            Debug.Log(hit.collider.gameObject.name);
        }else {
            laser.SetActive(false);
        }
    }

    private void ShowLaser(RaycastHit hit) {

        laser.SetActive(true);

        laserTransform.position = Vector3.Lerp(transform.position, hitPoint, .5f);

        laserTransform.LookAt(hitPoint);

        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }
}
