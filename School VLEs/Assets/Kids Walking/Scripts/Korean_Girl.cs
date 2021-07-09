using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Korean_Girl : MonoBehaviour
{
    public GameObject KoreanGirlAvatar;
    public Animator KoreanGirlAnim;
    bool firstTurn, secondTurn, valuesStored = false;
    Vector3 koreanGirlInitialPosition;
    public Quaternion originalRotationValue;

    //Animation breaks after 6 iterations

    private void Start()
    {
        //koreanGirlInitialPosition = new Vector3(KoreanGirlAvatar.transform.position.x, KoreanGirlAvatar.transform.position.y, KoreanGirlAvatar.transform.position.z);
        //originalRotationValue = KoreanGirlAvatar.transform.rotation;
    }

    IEnumerator TurningCoroutine()
    {
        yield return new WaitForSeconds(4.5f);
        KoreanGirlAnim.SetBool("isTurning", false);
    }

    IEnumerator TurningCoroutine2()
    {
        yield return new WaitForSeconds(4.4f);
        KoreanGirlAnim.SetBool("isTurning", false);
    }


    private void Update()
    {
        if(KoreanGirlAvatar.activeSelf == true && !valuesStored)
        {
            koreanGirlInitialPosition = new Vector3(KoreanGirlAvatar.transform.position.x, KoreanGirlAvatar.transform.position.y, KoreanGirlAvatar.transform.position.z);
            originalRotationValue = KoreanGirlAvatar.transform.rotation;
            valuesStored = true;
        }

        if(KoreanGirlAvatar.transform.position.z < -32 && !firstTurn)
        {
            KoreanGirlAnim.SetBool("isTurning", true);
            firstTurn = true;
            StartCoroutine(TurningCoroutine());

        }

        if (KoreanGirlAvatar.transform.position.x > -2.0f && !secondTurn)
        {
            KoreanGirlAnim.SetBool("isTurning", true);
            secondTurn = true;
            StartCoroutine(TurningCoroutine2());

        }

        if (KoreanGirlAvatar.transform.position.z > -7 && firstTurn)
        {

            KoreanGirlAvatar.transform.position = koreanGirlInitialPosition;
            KoreanGirlAvatar.transform.rotation = originalRotationValue;
            //KoreanGirlAvatar.SetActive(false);
            firstTurn = false;
            secondTurn = false;
        }

    }
}
