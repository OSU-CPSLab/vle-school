using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWay_2_Entry : MonoBehaviour
{
    //Attach wrongway txt 2 to Wrong way and ste it to false;
    public GameObject WrongWay_2Text;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "camera")
        {
            WrongWay_2Text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "camera")
        {
            WrongWay_2Text.SetActive(false);
        }
    }
}
