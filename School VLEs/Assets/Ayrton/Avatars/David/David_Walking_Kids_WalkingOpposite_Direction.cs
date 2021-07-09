using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class David_Walking_Kids_WalkingOpposite_Direction : MonoBehaviour
{
    public GameObject DavidAvatar;
    Vector3 DavidInitialPosition;
    Vector3 DavidPositionOffset;
    Quaternion originalRotationValue;
    Animator DavidAnimator;
    bool storedValues = false;
    bool firstTurn = false;
    bool secondTurn = false;
    bool thirdTurn = false;
    bool fourthTurn = false;
    public float yOffset;

    IEnumerator TurningCoroutine()
    {
        DavidAvatar.transform.position = DavidPositionOffset;
        yield return new WaitForSeconds(1.5f);
        DavidAnimator.SetBool("isTurningLeft", false);
        //Adding a little y offset
        //DavidAvatar.transform.position = DavidPositionOffset;
    }

    public void Update()
    {
        if(DavidAvatar.activeSelf == true)
        {
            //Constantly updating current position of David and adding a small y offset to fix turning animation
            DavidPositionOffset = new Vector3(DavidAvatar.transform.position.x, DavidAvatar.transform.position.y + yOffset, DavidAvatar.transform.position.z);

            if (!storedValues)
            {
                originalRotationValue = DavidAvatar.transform.rotation;
                DavidInitialPosition = new Vector3(DavidAvatar.transform.position.x, DavidAvatar.transform.position.y, DavidAvatar.transform.position.z);
                DavidAnimator = DavidAvatar.GetComponent<Animator>();
                storedValues = true;
            }
        }

        if(DavidAvatar.transform.position.z < -32.0f && !firstTurn)
        {
            DavidAnimator.SetBool("isTurningLeft", true);
            firstTurn = true;
            StartCoroutine(TurningCoroutine());
        }

        if (DavidAvatar.transform.position.x > 0.0f && !secondTurn)
        {
            DavidAnimator.SetBool("isTurningLeft", true);
            secondTurn = true;
            StartCoroutine(TurningCoroutine());
        }

        if (DavidAvatar.transform.position.z > -8.0f && firstTurn && !thirdTurn)
        {
            DavidAnimator.SetBool("isTurningLeft", true);
            thirdTurn = true;
            StartCoroutine(TurningCoroutine());
        }

        if (DavidAvatar.transform.position.x > 0.0f && firstTurn && secondTurn && thirdTurn && !fourthTurn)
        {
            DavidAnimator.SetBool("isTurningLeft", true);
            fourthTurn = true;
            StartCoroutine(TurningCoroutine());
        }

        if (fourthTurn)
        {
            firstTurn = false;
            secondTurn = false;
            thirdTurn = false;
            fourthTurn = false;
        }
    }
}
