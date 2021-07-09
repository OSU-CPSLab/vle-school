using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourClassroomDoorHallway : MonoBehaviour {
    public GameObject longBar;
    public GameObject shortBar;
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
    Collider nobDoorCollider;

    void OnTriggerEnter(Collider other) {
        //Debug.Log(other.name);

        //Door handle - Enter
        longBar.transform.Rotate(0, 0, 20f);
        longBar.transform.position = longBarOpenedPosition;
        //LittlePart of doorhandle - Enter
        shortBar.transform.Rotate(0, 0, 20f);
        shortBar.transform.position = shortBarOpenedPosition;
        HandInDoor = true;
        }

    void OnTriggerExit(Collider other) {
        //Debug.Log(other.name);
        //Door handle - Exit
        if (!doorIsOpen) {
            longBar.transform.Rotate(0, 0, -20f);
            longBar.transform.position = longBarInitialPosition;
            //LittlePart of doorhandle - Exit
            shortBar.transform.Rotate(0, 0, -20f);
            shortBar.transform.position = shortBarInitialPosition;
            HandInDoor = false;
        }

        if (doorIsOpen) {
            nobDoorCollider.enabled = !nobDoorCollider.enabled;
            Debug.Log("Bar handler collider has been disabled");
            backOfDoor.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start() {
        nobDoorCollider = GetComponent<Collider>();
        longBarInitialPosition = new Vector3(longBar.transform.position.x, longBar.transform.position.y, longBar.transform.position.z);
        Debug.Log("LongInitial: " + longBarInitialPosition);
        shortBarInitialPosition = new Vector3(shortBar.transform.position.x, shortBar.transform.position.y, shortBar.transform.position.z);
        Debug.Log("ShortInitial: " + shortBarInitialPosition);
        longBarOpenedPosition = new Vector3(longBarInitialPosition.x, longBarInitialPosition.y - 0.0244f, longBarInitialPosition.z);
        Debug.Log("LongOpened: " + longBarOpenedPosition);
        shortBarOpenedPosition = new Vector3(shortBarInitialPosition.x, shortBarInitialPosition.y - 0.0015f, shortBarInitialPosition.z - 0.006f);
        Debug.Log("ShortOpened"+shortBarOpenedPosition);
        doorInitialPosition = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
        Debug.Log("DoorInitial" + doorInitialPosition);
        doorOpenedPosition = new Vector3(doorInitialPosition.x + 0.51f, doorInitialPosition.y, doorInitialPosition.z - 0.481f);
        Debug.Log("DoorOpened" + doorOpenedPosition);
    }

    // Update is called once per frame
    void Update() {
        if (HandInDoor == true && HELP.activeSelf == true && DoorOpenedFromInsideRoom.activeSelf == false) {
            Debug.Log("Hand in door and trigger pressed");
            door.transform.Rotate(0, 90f, 0);
            door.transform.position = doorOpenedPosition;
            doorIsOpen = true;
            DoorOpenedFromHallway.SetActive(true);
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
            nobDoorCollider.enabled = true;
            longBar.transform.Rotate(0, 0, -20f);
            longBar.transform.position = longBarInitialPosition;
            shortBar.transform.Rotate(0, 0, -20f);
            shortBar.transform.position = shortBarInitialPosition;
            DoorOpenedFromHallway.SetActive(false);
        }
    }
}
