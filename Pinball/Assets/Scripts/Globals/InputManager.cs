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
	public delegate void ActionKey(KeyCode key);
	#endregion

	#region Events
	public event ActionKey OnKeyHeld;
	public event ActionKey OnKeyUp;
	#endregion

	public KeyCode p1Left = KeyCode.Alpha1;
	public KeyCode p1Right = KeyCode.Alpha2;
	public KeyCode p2Left = KeyCode.Alpha9;
	public KeyCode p2Right = KeyCode.Alpha0;

	private bool p1LeftDown = false;
	private bool p1RightDown = false;
	private bool p2LeftDown = false;
	private bool p2RightDown = false;

	// Update is called once per frame
	public void Update () {
		// Reduces number of calls for polling input.
		if (OnKeyHeld != null) {
			// P1 Left
			if (Input.GetKey(p1Left)) {
				p1LeftDown = true;
				OnKeyHeld (p1Left);
			} else {
				if (p1LeftDown) {
					OnKeyUp(p1Left);
					p1LeftDown = false;
				}
			}
			// P1 Right
			if (Input.GetKey(p1Right)) {
				OnKeyHeld (p1Right);
			} else {
				if (p1RightDown) {
					OnKeyUp(p1Right);
				}
			}
			// P2 Left
			if (Input.GetKey(p2Left)) {
				OnKeyHeld (p2Left);
			} else {
				if (p2LeftDown) {
					OnKeyUp(p2Left);
				}
			}
			// P2 Right
			if (Input.GetKey(p2Right)) {
				OnKeyHeld (p2Right);
			} else {
				if (p2RightDown) {
					OnKeyUp(p2Right);
				}
			}
		} 
	}

	// Resets all the delegates.
	public void Reset() {
		OnKeyHeld = null;
	}

	#region Register with delegates	
	public void RegisterOnKeyHeld(ActionKey a) {
		OnKeyHeld += a;
	}
	public void DeregisterOnKeyHeld(ActionKey a) {
		OnKeyHeld -= a;
	}
	public void RegisterOnKeyUp(ActionKey a) {
		OnKeyUp += a;
	}
	public void DeregisterOnKeyUp(ActionKey a) {
		OnKeyUp += a;
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





