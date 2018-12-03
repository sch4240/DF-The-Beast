using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour {

	public GameObject uiScreen;
	// Update is called once per frame
	void Update () {
		CheckTabButton();
	}

	void CheckTabButton()
	{
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			if(uiScreen.activeSelf==true)
				uiScreen.SetActive(false);
			else if(uiScreen.activeSelf==false)
				uiScreen.SetActive(true);
		}
	}
}
