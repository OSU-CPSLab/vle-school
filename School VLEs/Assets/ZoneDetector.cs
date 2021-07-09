using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetector : MonoBehaviour
{
	public Animator avatarAnimator;
	public int id = 0;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "camera")
		{
			if (avatarAnimator.GetInteger("CurrentZone") == id && !avatarAnimator.GetBool("IsWalking"))
			{
				StartCoroutine(ChangeAnimatorState());
			}
		}
	}

	private IEnumerator ChangeAnimatorState()
	{
		avatarAnimator.SetBool("CanMove", true);

		yield return new WaitForSeconds(0.5f);

		avatarAnimator.SetBool("CanMove", false);
	}
}
