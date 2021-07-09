using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Material color;
    // Start is called before the first frame update
    void Awake()
    {
        var go1 = new GameObject { name = "Circle" };
        go1.DrawCircle(.5f, .03f, this.gameObject, color);
        go1.transform.parent = this.gameObject.transform;
        if(this.gameObject.name == "Circle Container 1")
        {
            this.gameObject.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        }

        if (this.gameObject.name == "Circle Container 2")
        {
            this.gameObject.transform.Rotate(0.0f, 0.0f, -90.0f, Space.Self);
        }

        if (this.gameObject.name == "Circle Container 3")
        {
            this.gameObject.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
