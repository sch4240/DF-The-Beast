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

        // get reference to Sound Effect Manager
        SEManager = GameObject.FindObjectOfType<SoundEffectManager>();
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
