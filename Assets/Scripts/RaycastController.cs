using UnityEngine;

public class RaycastController : MonoBehaviour {

	public LayerMask interactLayer;

	public InteractableItemBase focus;

	public bool isObjectFocused = false; // true when any object is being focused.
	Camera cam;

	private void Awake() {
		cam = Camera.main;
	}

	private void Update() {
		FireRaycast();
	}
	public void FireRaycast()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit,100,interactLayer))
		{
			// /Debug.Log("Hitting!!!!");
			InteractableItemBase interactable = hit.collider.GetComponent<InteractableItemBase>();
			if(interactable!=null&&Input.GetKeyDown(KeyCode.F))
			{
				SetFocus(interactable);
				//Debug.Log(interactable.name);
			}

		}
		else
		{
			RemoveFocus();
			//Debug.Log("Not Focused");
		}
		
	}

	public void SetFocus(InteractableItemBase newFocus)
	{
		if(newFocus != focus)
		{
			if(focus!=null)
				focus.OnDefocused();

			focus = newFocus;
			isObjectFocused = true;
		}
		
		newFocus.OnFocused(this.transform);
		
	}

	public void RemoveFocus()
	{
		if(focus!=null)
				focus.OnDefocused();
		focus =null;
		isObjectFocused = false;
	}
}
