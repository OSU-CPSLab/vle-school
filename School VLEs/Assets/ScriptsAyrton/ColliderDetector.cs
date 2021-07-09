using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ColliderDetector : MonoBehaviour
{
    public GameObject handleBar;
    public GameObject bottomHandleBar;
    bool HandInDoor = false;
    bool HandInBackOfDoor = false;
    bool doorIsOpen = false;
    float time = 0.0f;

    public GameObject HELP;
    public GameObject door;
    public GameObject backOfDoor;

    //Components of Door 6th Grade
    Vector3 longBarInitialPosition;
    Vector3 shortBarInitialPosition;
    Vector3 longBarOpenedPosition;
    Vector3 shortBarOpenedPosition;
    Vector3 doorInitialPosition;
    Vector3 doorOpenedPosition;
    Collider m_Collider;

    //Components of door Your Classroom
    Vector3 YOURCLASSROOMlongBarInitialPosition;
    Vector3 YOURCLASSROOMshortBarInitialPosition;
    Vector3 YOURCLASSROOMlongBarOpenedPosition;
    Vector3 YOURCLASSROOMshortBarOpenedPosition;
    Vector3 YOURCLASSROOMdoorInitialPosition;
    Vector3 YOURCLASSROOMdoorOpenedPosition;

    void OnTriggerEnter(Collider other) {
        //Debug.Log(other.name);

        //Door handle - Enter
        handleBar.transform.Rotate(0, 0, 20f);
        handleBar.transform.position = longBarOpenedPosition;
        //LittlePart of doorhandle - Enter
        bottomHandleBar.transform.Rotate(0, 0, 20f);
        bottomHandleBar.transform.position = shortBarOpenedPosition;
        HandInDoor = true;
    }

    void OnTriggerExit(Collider other) {
        //Debug.Log(other.name);
        //Door handle - Exit
        if (!doorIsOpen) {
            handleBar.transform.Rotate(0, 0, -20f);
            handleBar.transform.position = longBarInitialPosition;
            //LittlePart of doorhandle - Exit
            bottomHandleBar.transform.Rotate(0, 0, -20f);
            bottomHandleBar.transform.position = shortBarInitialPosition;
            HandInDoor = false;
        }

        if(doorIsOpen){
            m_Collider.enabled = !m_Collider.enabled;
            Debug.Log("Bar handler collider has been disabled");
            backOfDoor.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        longBarInitialPosition = new Vector3(-16.4952f, 1.3418f, -7.3111f);
        shortBarInitialPosition = new Vector3(-16.424f, 1.3418f, -7.3242f);

        longBarOpenedPosition = new Vector3(-16.4952f, 1.3166f, -7.3111f);
        shortBarOpenedPosition = new Vector3(-16.4288f, 1.3403f, -7.3242f);

        doorInitialPosition = new Vector3(-16.925f, 1.401f, -7.384f);
        doorOpenedPosition = new Vector3(-17.5158f, 1.401f, -6.686f);
    }

    void Update()
    {
        if(HandInDoor == true && HELP.activeSelf == true) {
            Debug.Log("Hand in door and trigger pressed");
            door.transform.Rotate(0, -90f, 0);
            door.transform.position = doorOpenedPosition;
            doorIsOpen = true;
            HandInDoor = false;
        }

        if (backOfDoor.activeSelf == true) {
            time += Time.deltaTime;
        }

        if(time >= 60.0f) {
            time = 0.0f;
            doorIsOpen = false;
            backOfDoor.SetActive(false);
            door.transform.Rotate(0, 90f, 0);
            door.transform.position = doorInitialPosition;
            m_Collider.enabled = true;
            handleBar.transform.Rotate(0, 0, -20f);
            handleBar.transform.position = longBarInitialPosition;
            bottomHandleBar.transform.Rotate(0, 0, -20f);
            bottomHandleBar.transform.position = shortBarInitialPosition; 
        }
    }
}
