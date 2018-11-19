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
    public float flickerTime;

	// Use this for initialization
	void Start () {
        // get light and intensity
        myLight = gameObject.GetComponent<Light>();
        intensity = myLight.intensity;

        // start flickering
        flicker();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // flicker function
    void flicker()
    {
        // add or subtract to intensity
        int num = Random.Range(0, 1);

        if(num == 0)
        {
            // make sure not too intense
            if (myLight.intensity >= intensity + flickerAmount * 3)
            {
                // subtract instead
                myLight.intensity -= flickerAmount;
            }
            else
            {
                myLight.intensity += flickerAmount;
            }
        }
        else
        {
            // make sure not too light
            if (myLight.intensity <= intensity - flickerAmount * 3)
            {
                // add instead
                myLight.intensity += flickerAmount;
            }
            else
            {
                myLight.intensity -= flickerAmount;
            }
        }

        // call flicker again
        Invoke("flicker", flickerTime);
    }
}
