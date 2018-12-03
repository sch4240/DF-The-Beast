using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton
	public static Inventory instance;
	private void Awake() {
		if(instance !=null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
		}
		instance = this;
	}
	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;
	 
	public List<ItemBase> items = new List<ItemBase>();

	
	
	public bool Add(ItemBase item)
	{
		items.Add(item);

		if(onItemChangedCallback!=null)
		{
			onItemChangedCallback.Invoke();
		}
			

		return true;
	}

	public bool Remove(ItemBase item)
	{
		items.Remove(item);
		if(onItemChangedCallback!=null)
			onItemChangedCallback.Invoke();

		return false;
	}
}
