using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public Image icon;
	ItemBase item;

	public ItemBase GetItem{get{return item;}}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsEmpty()
	{
		if(item)
			return false;

		return true;
	}

	public void AddItem(ItemBase newItem)
	{
		item = newItem;
		icon.sprite = newItem.icon;
		icon.enabled = true;
	}

	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
	}

}
