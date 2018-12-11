using UnityEngine;
using UnityEngine.UI;

public class ItemPanelScript : MonoBehaviour {

	public Image itemSprite;
	public Text itemName;
	public Text itemDescripton;
	
	public void ChangePanelContent(Sprite iS, string iN, string iD)
	{
		itemSprite.sprite = iS;
		itemName.text = iN;
		itemDescripton.text = iD;
	}
}
