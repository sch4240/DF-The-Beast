using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    // reference to light and light intensity
    Light myLight;
    float intensity;

    // amount of flicker
    public float flickerAmount;

    // time between flickers
    public float flickerTimeMax;
    public float flickerTimeMin;

	// Use this for initialization
	void Start () {
        // get light and intensity
        myLight = gameObject.GetComponent<Light>();
        intensity = myLight.intensity;

        // start flickering
        Flicker();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // reset the light to it's original intensity
    void LightReset()
    {
        myLight.intensity = intensity;
    }

    // flicker function
    void Flicker()
    {
        // add or subtract to intensity
        float flicker = Random.Range(-flickerAmount, flickerAmount);

        // amount of time to wait
        float time = Random.Range(flickerTimeMin, flickerTimeMax);

        // change light intensity (The actual flicker)
        myLight.intensity = intensity + flicker;

        // reset light
        Invoke("LightReset", time/2);

        // call flicker again
        Invoke("Flicker", time);
    }
}
