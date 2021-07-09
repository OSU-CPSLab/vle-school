using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairWalker : MonoBehaviour
{
    public float offset = 1.8f;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForStair();
    }

    public void CheckForStair()
    {
        RaycastHit hit;
        Ray ray = new Ray(camera.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "stair")
            {
                transform.position -= Vector3.up * (hit.distance - offset);
            }
        }
    }
}
