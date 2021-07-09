using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour {

    /*public SteamVR_Action_Vector2 input;
    public float speed = 1;

    void Update() {
        transform.position += speed * Time.deltaTime * new Vector3(input.axis.x, 0, input.axis.y);
    }
    */

    public SteamVR_Action_Boolean moveAction = null;
    public SteamVR_Action_Boolean topTouchPad = null;
    public SteamVR_Action_Boolean moveLeft = null;
    public SteamVR_Action_Boolean moveRight = null;
    public SteamVR_Action_Boolean DoorTrigger = null;

    //public SteamVR_Action_Boolean holdTrigger = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    public float speed = 300;

    public int XrotationCameraOffset;
    public int ZrotationCameraOffset;
    public GameObject doorHandle;
    public GameObject topTouchPadHasBeenPressed;
    public GameObject triggerActivator;

    public GameObject player;
    public Camera cam;
    private void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    public Transform target;
    public GameObject cameraR;
    public GameObject currFloor;

    public float speedMovement;

    //Vector3 cameraCoordinates;

    private void Update()
    {
        doorHandle.SetActive(false);
        triggerActivator.SetActive(false);
        topTouchPadHasBeenPressed.SetActive(false);
        if (moveAction.GetState(m_Pose.inputSource))
        {
            //Vector3 targetFloor = new Vector3(target.position.x, 0, target.position.z);
            //Vector3 targetFloor = new Vector3(target.position.x, currFloor.transform.position.y, target.position.z);
            //01/18/21

            //Current speed 0.02f
            Vector3 movement = cam.transform.forward * speedMovement * Time.deltaTime;
            movement.y = 0;
            cameraR.transform.Translate(movement);
        }

        if (moveLeft.GetStateDown(m_Pose.inputSource)) {
            //Debug.Log(m_Pose.inputSource + " Button Left");
            //player.transform.Rotate(XrotationCameraOffset, -90, ZrotationCameraOffset);
        }

        if (moveRight.GetStateDown(m_Pose.inputSource)) {
            //Debug.Log(m_Pose.inputSource + " Button Right");
            //player.transform.Rotate(XrotationCameraOffset, 90, ZrotationCameraOffset);
        }

        if (DoorTrigger.GetStateDown(m_Pose.inputSource)) {
            Debug.Log("Trigger Down");
            doorHandle.SetActive(true);
            triggerActivator.SetActive(true);
            //doorHandle.activeSelf == true
            //Debug.Log("Hand in door and trigger pressed");
        }

        if (DoorTrigger.GetStateUp(m_Pose.inputSource)) {
            Debug.Log("Trigger Up");
        }

        if (topTouchPad.GetStateDown(m_Pose.inputSource)) {
            topTouchPadHasBeenPressed.SetActive(true);
            
            
        }

        /*if (moveAction.GetStateUp(m_Pose.inputSource))
        {
            Debug.Log(m_Pose.inputSource + " Button Up");
        }
        */
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Long Piece")
        {
            Debug.Log("Collision with Doorhandle");
        }
    }
}
