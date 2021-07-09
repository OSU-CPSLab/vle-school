using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : MonoBehaviour
{
    public GameObject Text2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camera")
        {
            Debug.Log("Text1: Deactivated");

            //Deactivate Text1
            this.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            GameObject Arrow = this.transform.GetChild(0).gameObject;
            Arrow.SetActive(false);

            //Activate Text2
            Text2.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Deactivate Text 1
            this.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            GameObject Arrow = this.transform.GetChild(0).gameObject;
            Arrow.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.gameObject.GetComponentInChildren<Renderer>().enabled = true;
            GameObject Arrow = this.transform.GetChild(0).gameObject;
            Arrow.SetActive(true);
        }
    }
}
