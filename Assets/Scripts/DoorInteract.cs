using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{

    public float interactDistance;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckDoor();
    }

    void CheckDoor()
    {
        // open/close door on F
        if (Input.GetKeyDown(KeyCode.F) == true)
        {
            // create raycast
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    if (hit.collider.GetComponent<AnimScript>().ifOpen)
                    {
                        hit.collider.GetComponent<AnimScript>().CloseDoor();
                    }
                    else
                    {
                        hit.collider.GetComponent<AnimScript>().OpenDoor();
                    }
                }
            }
        }
    }
}
