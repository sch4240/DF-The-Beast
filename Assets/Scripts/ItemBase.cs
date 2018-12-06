using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName="Inventory/Item")]
public class ItemBase : ScriptableObject 
{
	new public string name = "New Item";
	public Sprite icon = null;

	public string tag = "New Tag";

}
