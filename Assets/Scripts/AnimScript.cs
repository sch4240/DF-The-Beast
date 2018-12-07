using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {
    private Animation anim;
    public bool ifOpen;
    public float interactDistance = 5.0f;

    // name of animation
    public string animationOpenName;
    public string animationCloseName;

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
        /*
        if (Input.GetKeyDown(KeyCode.O) == true && ifOpen == false)
        {
            // create raycast
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // check if looking at door
            if(Physics.Raycast(ray, out hit, interactDistance))
            {
                Debug.Log("We here?");
                if(hit.collider.CompareTag("Door"))
                {
                    hit.collider.GetComponent<AnimScript>().OpenDoor();
                }
            }

            ifOpen = true;

            // play sound effect
            SEManager.PlayCreak();
        }

        if (Input.GetKeyDown(KeyCode.C) == true && ifOpen==true)
        {
            // create raycast
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // check if looking at door
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.GetComponent<AnimScript>().CloseDoor();
                }
            }

            ifOpen = false;

            // play sound effect
            SEManager.PlayCreak();
        }
        */
    }


    public void OpenDoor()
    {
        anim.Play(animationOpenName);
        ifOpen = true;

        // play sound effect
        SEManager.PlayCreak();
    }

    public void CloseDoor()
    {
        anim.Play(animationCloseName);
        ifOpen = false;

        // play sound effect
        SEManager.PlayCreak();
    }
}
