using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;

	private int currentClip = 0;
    private AudioSource source;

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void PlayNextClip()
    {
		source.clip = clips[currentClip];
		source.Play();

		currentClip++;
    }

}
