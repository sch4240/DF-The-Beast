using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    // reference to light and light intensity
    Light myLight;

    // time between flashes
    public float minTime = 1f;
    public float maxTime = 10f;


    // Use this for initialization
    void Start () {
        // get light and set to inactive
        myLight = gameObject.GetComponent<Light>();
        myLight.enabled = false;

        // start lightning
        LightFlash();
    }
	
    // lightning coroutine
    void LightFlash()
    {
        // time to wait before next lightning flash
        float time = Random.Range(minTime, maxTime);
        Invoke("LightFlash", time);

        // turn light on, wait a little, then turn it off
        myLight.enabled = true;
        Invoke("LightOff", 0.15f);

    }

    void LightOff()
    {
        myLight.enabled = false;
    }
	
}
