using UnityEngine;
using System.Collections;

/*
	 * How to use:
	 * 
	 * 1. Create an input manager in your singleton.
	 * 2. Each script that needs to use this script must register to the event.
	 * 
	 * @Brian Chen
	 */


public class InputManager : Singleton{
	
	#region delegates
	public delegate void Action();
	#endregion

	#region Events
	public event Action OnKeyHeld;
	#endregion
	

	// Update is called once per frame
	public void Update () {
		// Reduces number of calls for polling input.
		if (OnKeyHeld != null && Input.anyKey) {
			OnKeyHeld();
		}
	}

	// Resets all the delegates.
	public void Reset() {
		OnKeyHeld = null;
	}

	#region Register with delegates	
	public void RegisterOnKeyHeld(Action a) {
		OnKeyHeld += a;
	}

	public void DeregisterOnKeyHeld(Action a) {
		OnKeyHeld -= a;
	}
	#endregion

	#region Inherited functions
	protected override void DestroyIfMoreThanOneOnObject(){
		if (transform.GetComponents<InputManager>().Length > 1){
			Debug.Log ("Destroying Extra " + this.GetType() + " Attachment");
			DestroyImmediate(this);
		}
	}
	
	#endregion
}





