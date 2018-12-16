using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorScript : AnimScript {

	public string keyName;

	public override void Interact()
	{
		if(Inventory.instance.CheckForItem(keyName))
			base.Interact();
	}

	
}
