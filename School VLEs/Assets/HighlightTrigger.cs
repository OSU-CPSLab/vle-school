using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTrigger : MonoBehaviour
{
    public GameObject highlight;
    public string targetTag;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Hello");
		if (other.tag == targetTag)
		{
			highlight.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == targetTag)
		{
			highlight.SetActive(false);
		}
	}
}
