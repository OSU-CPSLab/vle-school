using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Korean_Girl2 : MonoBehaviour
{
    public GameObject KoreanGirlAvatar;
    public Animator KoreanGirlAnim;
    bool firstTurn, secondTurn, valuesStored = false;
    Vector3 koreanGirlInitialPosition;
    public Quaternion originalRotationValue;
    int counter = 0;
    bool valueStored = false;

    //Animation breaks after 6 iterations

    private void Start()
    {
        //koreanGirlInitialPosition = new Vector3(KoreanGirlAvatar.transform.position.x, KoreanGirlAvatar.transform.position.y, KoreanGirlAvatar.transform.position.z);
        //originalRotationValue = KoreanGirlAvatar.transform.rotation;
    }

    IEnumerator TurningLeft()
    {
        yield return new WaitForSeconds(2.7f);
        KoreanGirlAnim.SetBool("turnLeft", false);
    }

    private void Update()
    {

        if (KoreanGirlAvatar.activeSelf == true && !valuesStored)
        {
            koreanGirlInitialPosition = new Vector3(KoreanGirlAvatar.transform.position.x, KoreanGirlAvatar.transform.position.y, KoreanGirlAvatar.transform.position.z);
            originalRotationValue = KoreanGirlAvatar.transform.rotation;
            valuesStored = true;
        }

        if (KoreanGirlAvatar.transform.position.z < -29.5 && !firstTurn)
        {
            KoreanGirlAnim.SetBool("turnRight", true);
            firstTurn = true;
        }

        if (KoreanGirlAvatar.transform.position.x < -25 && !secondTurn)
        {
            KoreanGirlAnim.SetBool("turnRight", false);
            KoreanGirlAnim.SetBool("turnLeft", true);
            secondTurn = true;
            StartCoroutine(TurningLeft());
        }

        if (KoreanGirlAvatar.transform.position.z < -36 && firstTurn)
        {
            //KoreanGirlAnim.SetBool("turnRight", false);
            KoreanGirlAvatar.transform.position = koreanGirlInitialPosition;
            KoreanGirlAvatar.transform.rotation = originalRotationValue;
            KoreanGirlAvatar.transform.Rotate(0.0f, 5.0f, 0.0f, Space.Self);
            counter++;
            firstTurn = false;
            secondTurn = false;
        }

        //Only play animation three times
        if(counter == 3)
        {
            KoreanGirlAvatar.SetActive(false);
        }
    }
}