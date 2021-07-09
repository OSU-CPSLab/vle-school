using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAvatar : MonoBehaviour
{
    public Animator avatarAnimator;
    bool assemblyStarted = false;
    public GameObject basePlateSnappingHighLighted, buffer1SnappingHighLighted, middlePlateSnappingHighLighted, buffer2SnappingHighLighted, topPlateSnappingHighLighted, bolt1SnappingHighLighted, bolt2SnappingHighLighted, nut1SnappingHighLighted, nut2SnappingHighLighted;
    AudioSource basePlateSnapping, buffer1Snapping, middlePlateSnapping,buffer2Snapping, topPlateSnapping, bolt1Snapping, bolt2Snapping, nut1Snapping, nut2Snapping;

    void AssemblyStarted() {
        assemblyStarted = true;
    }

    void Start() {
        basePlateSnapping = basePlateSnappingHighLighted.GetComponent<AudioSource>();
    }

    void Update()
    {
        avatarAnimator.SetBool("isTalking", false);

        if (buffer1SnappingHighLighted) {
            buffer1Snapping = buffer1SnappingHighLighted.GetComponent<AudioSource>();
        }

        if (middlePlateSnappingHighLighted.activeSelf == true) {
            middlePlateSnapping = middlePlateSnappingHighLighted.GetComponent<AudioSource>();
        }

        if (buffer2SnappingHighLighted.activeSelf == true) {
            buffer2Snapping = buffer2SnappingHighLighted.GetComponent<AudioSource>();
        }

        if (topPlateSnappingHighLighted.activeSelf == true) {
            topPlateSnapping = topPlateSnappingHighLighted.GetComponent<AudioSource>();
        }

        if (bolt1SnappingHighLighted.activeSelf == true) {
            bolt1Snapping = bolt1SnappingHighLighted.GetComponent<AudioSource>();
        }

        if (bolt2SnappingHighLighted.activeSelf == true) {
            bolt2Snapping = bolt2SnappingHighLighted.GetComponent<AudioSource>();
        }

        if (nut1SnappingHighLighted.activeSelf == true) {
            nut1Snapping = nut1SnappingHighLighted.GetComponent<AudioSource>();
        }

        if (nut2SnappingHighLighted.activeSelf == true) {
            nut2Snapping = nut2SnappingHighLighted.GetComponent<AudioSource>();
        }

        /*if (basePlateSnapping.isPlaying) {
            AssemblyStarted();
        }*/

        if (basePlateSnapping.isPlaying/* || buffer1Snapping.isPlaying || middlePlateSnapping.isPlaying ||buffer2Snapping.isPlaying || topPlateSnapping.isPlaying || bolt1Snapping.isPlaying || bolt2Snapping.isPlaying || nut1Snapping.isPlaying || nut2Snapping.isPlaying*/) {
            Debug.Log("Avatar is Talking Assembly");
            avatarAnimator.SetBool("isTalking", true);
        }

        /*if (!basePlateSnapping.isPlaying) {
            Debug.Log("Avatar is not talking but assembly started");
            avatarAnimator.SetBool("isTalking", false);
        }*/

        if (buffer1Snapping.isPlaying) {
            Debug.Log("Avatar is Talking");
            avatarAnimator.SetBool("isTalking", true);
        }

        if (middlePlateSnapping.isPlaying) {
            Debug.Log("Avatar is Talking");
            avatarAnimator.SetBool("isTalking", true);
        }

        if (buffer2Snapping.isPlaying) {
            Debug.Log("Avatar is Talking");
            avatarAnimator.SetBool("isTalking", true);
        }

        if (bolt1Snapping.isPlaying) {
            Debug.Log("Avatar is Talking");
            avatarAnimator.SetBool("isTalking", true);
        }

        if (bolt2Snapping.isPlaying) {
            Debug.Log("Avatar is Talking");
            avatarAnimator.SetBool("isTalking", true);
        }
        
        if (nut1Snapping.isPlaying) {
            Debug.Log("Avatar is Talking");
            avatarAnimator.SetBool("isTalking", true);
        }

        if (nut2Snapping.isPlaying) {
            Debug.Log("Avatar is Talking");
            avatarAnimator.SetBool("isTalking", true);
        }
        /*if (!basePlateSnapping.isPlaying) {
            Debug.Log("Avatar is not talking but assembly started");
            avatarAnimator.SetBool("isTalking", false);
        }*/

    }
}
