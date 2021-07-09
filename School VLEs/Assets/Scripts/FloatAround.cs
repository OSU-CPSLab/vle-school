using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAround : MonoBehaviour
{
    private Rigidbody rb;
    public bool spininplace;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 go = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        if (spininplace) {
            rb.angularVelocity = speed * go;
        } else {
            rb.velocity = speed * go;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
