using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2C_RestroomDoor : MonoBehaviour
{
    public Animator handleBar;
    public Animator door;

    private void Update()
    {
        if (handleBar.GetCurrentAnimatorStateInfo(0).IsName("O"))
        {
            door.SetBool("isOpening", true);
        }
    }
}
