using UnityEngine;

public class ItemPickup : InteractableItemBase {

	public override void Interact()
	{
		//base.Interact();

		Pickup();
	}

	void Pickup()
	{
		Debug.Log("Picking Up");

		Destroy(gameObject);
	}
}
