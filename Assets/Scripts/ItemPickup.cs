using UnityEngine;

public class ItemPickup : InteractableItemBase {

	public ItemBase item;

    // sound effect manager and clue to write in journal
    SoundEffectManager SEManager;
    public bool clue;
    public string clueString;

    public override void Interact()
	{
		//base.Interact();

		Pickup();
	}

	void Pickup()
	{
		//Debug.Log("Picking Up: "+item.name);
		Inventory.instance.Add(item);

        // if clue, play sound effect
        if(clue)
        {
            SEManager = FindObjectOfType<SoundEffectManager>();
            SEManager.PlayNewClue();

            //TODO: add clueString to the journal if we go down that route
        }

		Destroy(gameObject);
	}
}
