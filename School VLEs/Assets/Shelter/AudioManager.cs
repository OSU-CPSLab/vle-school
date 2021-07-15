using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;

	private int currentClip = 0;
    private AudioSource source;

	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
	}

	void PlayNextClip()
    {
		source.clip = clips[currentClip];
		source.Play();

		currentClip++;
    }

    private void Update() {
		animator.SetBool("IsAudioPlaying", source.isPlaying);
    }

}
