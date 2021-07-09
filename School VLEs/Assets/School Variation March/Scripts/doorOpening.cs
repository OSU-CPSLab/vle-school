using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpening : MonoBehaviour
{
    //Attach the corresponding Mesh2_manilla_door_handle1_Model
    public GameObject barHandle;
    GameObject door;
    Animator doorAnim;
    Animator barHandleAnim;
    float waitTime = 4.0f;                //Half the time since animation is -1 speed
    bool currentlyOpened = false;

    private void Start()
    {
        //Storing properties into variables
        door = this.gameObject;
        doorAnim = this.GetComponent<Animator>();
        barHandleAnim = barHandle.GetComponent<Animator>();
    }

    IEnumerator closeDoor()
    {
        currentlyOpened = true;
        yield return new WaitForSeconds(waitTime);

        //Close door automatically
        doorAnim.SetBool("isOpening", false);
        barHandleAnim.SetBool("isOpening", false);
        currentlyOpened = false;
    }

    private void Update()
    {
        if ((barHandleAnim.GetCurrentAnimatorStateInfo(0).IsName("isOpened")) && !currentlyOpened){
            doorAnim.SetBool("isOpening", true);
            StartCoroutine(closeDoor());
        }
    }
}
