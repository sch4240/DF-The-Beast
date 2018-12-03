﻿using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public Transform itemsParent;
	public Transform journalParent;

	InventorySlot[] slots;
	InventorySlot[] journalSlots;
	Inventory inventory;

	private void Start() {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		journalSlots = journalParent.GetComponentsInChildren<InventorySlot>();
	}

	void UpdateUI() {
		for(int i=0;i<slots.Length;i++)
		{
			if(i<inventory.items.Count)
			{
				journalSlots[i].AddItem(inventory.items[i]);
			}
			else
			{
				journalSlots[i].ClearSlot();
			}
		}
	}
	
}
