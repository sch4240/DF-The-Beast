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

    public Dictionary<string, string> correctClueReference = new Dictionary<string, string>();
    public Dictionary<string, string> misleadClueReference = new Dictionary<string, string>();

    void Start()
    {
        correctClueReference.Add("mirror", "What a phobophage uses to enter the world.");
        correctClueReference.Add("magic circle", "Magic attracts phobophages.");
        correctClueReference.Add("photographs", "Different shadow shapes in this photo suggest a shapeshifter");
        correctClueReference.Add("radio", "Static suggests a spiritual presence.");
        correctClueReference.Add("blood", "Vampires never waste blood.");
        correctClueReference.Add("journal entry #2", "Phobophages feed on fear and toy with their victims.");
        correctClueReference.Add("journal entry #3", "Multiple shadows were seen in the woods, suggesting a shapeshifter.");
        correctClueReference.Add("journal entry #4", "The phobophage showed up after she performed her latest ritual.");
        correctClueReference.Add("journal entry #5", "Evidence that phobophages toy with their victims.");
        correctClueReference.Add("hair", "The spell cast on the brush revealed that Laura saw multiple creatures before her death.");

        misleadClueReference.Add("mead", "Grendelkins like mead.");
        misleadClueReference.Add("blood", "White court vampires leave no evidence.");
        misleadClueReference.Add("journal entry #1", "A shadow in the woods suggests a mistfiend.");
        misleadClueReference.Add("old book", "The book tells stories of the old ones, who could've been stalking her.");
    }


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
