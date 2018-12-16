using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBoxInteract : InteractableItemBase {

	public ItemBase key;

	bool isKeyObtained;

	// Use this for initialization
	void Start () {
		isKeyObtained = false;
	}
	
	public override void Interact()
	{
		TurnLockBoxOn();
	}

	void TurnLockBoxOn()
	{
		UIMngr.Instance.ToggleLockBoxOn();
	}

	void Update() {
		base.Update();
		if(UIMngr.Instance.unlockedBox&&!isKeyObtained)
		{
			Inventory.instance.Add(key);
			isKeyObtained = true;
		}
			
	}
}
