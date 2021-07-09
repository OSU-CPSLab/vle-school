using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmScript : MonoBehaviour
{
    public Animator _animator;
    public bool redAlert = false;
    public bool blueAlert = false;

    public AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (redAlert)
        {
            blueAlert = false;
            //Sends the animation to "red alert"
            _animator.SetInteger("Transition", 1);

        }else if (blueAlert)
		{
            redAlert = false;
            //Sends the animation to "blue alert"
            _animator.SetInteger("Transition", 2);
        }
        else
        {
            _animator.SetInteger("Transition", 0);
        }
    }
}
