using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionPanelScript : InteractableItemBase {

	// Use this for initialization
	void Start () {
		
	}

	public override void Interact()
	{
		EnableDecisionPanel();
	}
	
	void EnableDecisionPanel()
	{
		UIMngr.Instance.ToggleLeaving();
	}

	
}
