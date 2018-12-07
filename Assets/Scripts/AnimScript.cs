using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {
    private Animation anim;
    private bool ifOpen;

    // sound effect variables
    SoundEffectManager SEManager;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animation>();
        ifOpen = true;

        // get reference to Sound Effect Manager
        SEManager = GameObject.FindObjectOfType<SoundEffectManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O) == true && ifOpen == false)
        {
            anim.Play("Door Open");
            ifOpen = true;

            // play sound effect
            SEManager.PlayCreak();
        }

        if (Input.GetKeyDown(KeyCode.C) == true && ifOpen==true)
        {
            anim.Play("Door Anim");
            ifOpen = false;

            // play sound effect
            SEManager.PlayCreak();
        }
    }

}
