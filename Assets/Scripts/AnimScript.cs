using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : InteractableItemBase {
    protected Animation anim;
    public bool ifOpen;

    // name of animation
    public string animationOpenName;
    public string animationCloseName;

    // sound effect variables
    SoundEffectManager SEManager;

    // Use this for initialization
    protected void Start ()
    {
        anim = GetComponent<Animation>();

        // get reference to Sound Effect Manager
        SEManager = GameObject.FindObjectOfType<SoundEffectManager>();
    }

    public override void Interact()
    {
        if(ifOpen)
        {
            ifOpen = !ifOpen; 
            CloseDoor();
        }
        else
        {
            ifOpen = !ifOpen; 
            OpenDoor();
        }
          
    }





    public void OpenDoor()
    {
        anim.Play(animationOpenName);

        // play sound effect
        SEManager.PlayCreak();
    }

    

    public void CloseDoor()
    {
        anim.Play(animationCloseName);

        // play sound effect
        SEManager.PlayCreak();
    }

}
