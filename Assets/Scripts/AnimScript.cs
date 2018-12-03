using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {
    private Animator anim;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O)==true)
        {
            anim.SetTrigger("openingDoor");
            anim.SetBool("doorClosed", false);
            anim.SetBool("doorOpen", true);
        }

        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            anim.SetTrigger("closingDoor");
            anim.SetBool("doorClosed", true);
            anim.SetBool("doorOpen", false);
        }
    }

}
