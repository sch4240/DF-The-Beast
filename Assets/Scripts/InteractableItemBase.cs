using UnityEngine;

public class InteractableItemBase : MonoBehaviour {

	public float radius = 1f;
	public Transform interactTransform;
	bool isCurrentFocus; // is this object the current focus of the player.
	bool hasInteracted=false;
	Transform player;

	public virtual void Interact()
	{
		Debug.Log("Interacting");
	}
	protected void Update() {
		if(isCurrentFocus&& !hasInteracted)
		{
			float distance = Vector3.Distance(player.position, interactTransform.position);
			if(distance <= radius)
			{
				hasInteracted = true;
				Interact();
			}
		}
	}
	public void OnFocused(Transform playerTransform)
	{
		isCurrentFocus =true;
		player = playerTransform;
	}

	public void OnDefocused()
	{
		isCurrentFocus = false;
		player = null;
		hasInteracted = false;
	}
	private void OnDrawGizmosSelected() {
		if(interactTransform==null)
		{
			interactTransform = this.transform;
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactTransform.position,radius);
	}
}
