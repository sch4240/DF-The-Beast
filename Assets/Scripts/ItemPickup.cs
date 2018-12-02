using UnityEngine;

public class ItemPickup : InteractableItemBase {

	public ItemBase item;

	public override void Interact()
	{
		//base.Interact();

		Pickup();
	}

	void Pickup()
	{
		Debug.Log("Picking Up: "+item.name);
		Inventory.instance.Add(item);
		Destroy(gameObject);
	}
}
