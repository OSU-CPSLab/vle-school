using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_4 : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Arrow1;
    //public GameObject flashingLight1;

    public GameObject Text2;
    public GameObject Arrow2;
    //public GameObject flashingLight2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "camera")
        {
            //Deactivate Text1 and arrow1
            Text1.SetActive(false);
            Arrow1.SetActive(false);
            //flashingLight1.SetActive(false);

            //Activate Text2 and arrow2
            Text2.SetActive(true);
            Arrow2.SetActive(true);
            //flashingLight2.SetActive(true);
        }
    }
}
