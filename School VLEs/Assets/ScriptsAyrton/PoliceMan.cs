﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMan : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;


    void Start()
    {
        anim = anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }
}
