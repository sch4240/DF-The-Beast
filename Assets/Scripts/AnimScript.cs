using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {
    private Animation anim;
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O) == true)
        {
            anim.Play();
        }

        if (Input.GetKeyDown(KeyCode.C) == true)
        {

        }
    }

}
