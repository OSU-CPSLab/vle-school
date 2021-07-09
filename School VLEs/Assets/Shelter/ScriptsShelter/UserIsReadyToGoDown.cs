using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIsReadyToGoDown : MonoBehaviour
{
    public GameObject userIsReadyToGoDown;
    public GameObject policeOfficerAvatar;
    bool AvatarRotationHasBeenFixed = false;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "GameController") {
            Debug.Log("UserIsReadyToGoDown");
            userIsReadyToGoDown.SetActive(true);
            if (!AvatarRotationHasBeenFixed) {
                FixRotation();
            }
        }
    }

    void FixRotation() {
        policeOfficerAvatar.transform.Rotate(0, /*26.39f*/5.0f, 0);
        AvatarRotationHasBeenFixed = true;
    }
}
