using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourClassroomDoorInsideRoom : MonoBehaviour {
    public GameObject handleBar;
    public GameObject bottomHandleBar;
    bool HandInDoor = false;
    bool HandInBackOfDoor = false;
    bool doorIsOpen = false;
    float time = 0.0f;

    public GameObject HELP;
    public GameObject door;
    public GameObject backOfDoor;

    public GameObject DoorOpenedFromHallway;
    public GameObject DoorOpenedFromInsideRoom;

    Vector3 longBarInitialPosition;
    Vector3 shortBarInitialPosition;
    Vector3 longBarOpenedPosition;
    Vector3 shortBarOpenedPosition;
    Vector3 doorInitialPosition;
    Vector3 doorOpenedPosition;
    Collider m_Collider;

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

        if (doorIsOpen) {
            m_Collider.enabled = !m_Collider.enabled;
            Debug.Log("Bar handler collider has been disabled");
            backOfDoor.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start() {
        m_Collider = GetComponent<Collider>();
        longBarInitialPosition = new Vector3(-2.7715f, 1.3269f, -0.5352051f);
        shortBarInitialPosition = new Vector3(-2.784f, 1.3269f, -0.464f);

        longBarOpenedPosition = new Vector3(-2.7715f, 1.3019f, -0.5352051f);
        shortBarOpenedPosition = new Vector3(-2.784f, 1.3254f, -0.4683f);

        doorInitialPosition = new Vector3(-2.84f, 1.401f, -0.865f);
        doorOpenedPosition = new Vector3(-2.233f, 1.401f, -1.346f);
    }

    // Update is called once per frame
    void Update() {
        if (HandInDoor == true && HELP.activeSelf == true && DoorOpenedFromHallway.activeSelf == false) {
            Debug.Log("Hand in door and trigger pressed");
            door.transform.Rotate(0, 90f, 0);
            door.transform.position = doorOpenedPosition;
            doorIsOpen = true;
            DoorOpenedFromInsideRoom.SetActive(true);
            HandInDoor = false;
        }

        if (backOfDoor.activeSelf == true) {
            time += Time.deltaTime;
        }

        if (time >= 8.0f) {
            time = 0.0f;
            doorIsOpen = false;
            backOfDoor.SetActive(false);
            door.transform.Rotate(0, -90f, 0);
            door.transform.position = doorInitialPosition;
            m_Collider.enabled = true;
            handleBar.transform.Rotate(0, 0, -20f);
            handleBar.transform.position = longBarInitialPosition;
            bottomHandleBar.transform.Rotate(0, 0, -20f);
            bottomHandleBar.transform.position = shortBarInitialPosition;
            DoorOpenedFromInsideRoom.SetActive(false);
        }
    }
}