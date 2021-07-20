using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_5 : MonoBehaviour
{
    public GameObject Arrow3;
    public GameObject Text3;

    public GameObject Arrow2;
    public GameObject Text2;

    public GameObject Arrow4;

    public GameObject flashingLigh1;
    public GameObject flashingLight2;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "camera")
        {
            //Deactivate text2 and arrow 2
            Arrow2.SetActive(false);
            Text2.SetActive(false);
            flashingLigh1.SetActive(false);

            //Activate text 3 and arrow 3 and arrow 4
            Arrow3.SetActive(true);
            Text3.SetActive(true);

            Arrow4.SetActive(true);
            flashingLight2.SetActive(true);
        }
    }
}
