﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {
    private Animation anim;
    private bool ifOpen;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animation>();
        ifOpen = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O) == true && ifOpen == false)
        {
            anim.Play("Door Open");
            anim.Play("BathOpen");
            anim.Play("CellarOpen");
            ifOpen = true;
        }

        if (Input.GetKeyDown(KeyCode.C) == true && ifOpen==true)
        {
            anim.Play("Door Anim");
            anim.Play("BathClose");
            anim.Play("CellarClose");
            ifOpen = false;
        }
    }

}
