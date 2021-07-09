using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMovement : MonoBehaviour
{
    public GameObject cameraRig;
    public GameObject currFloor;
    float speedMovement = 0.018f;
    float speedRotation = 15.0f;
    public Transform target;

    public GameObject camera;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Forward");
            Vector3 targetFloor = new Vector3(target.position.x, currFloor.transform.position.y, target.position.z);
            cameraRig.transform.position = Vector3.MoveTowards(cameraRig.transform.position, targetFloor, speedMovement);
        }

        if (Input.GetKey(KeyCode.A))
        {
            cameraRig.transform.Rotate(Vector3.down * speedRotation * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            cameraRig.transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
        }
    }
}
