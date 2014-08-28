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


public class GuiManager : Singleton{

	private GUIText mP1GuiText;
	private GUIText mP2GuiText;
	private GameState mGameState;

	new void Start(){
		base.Start();
		mGameState = transform.GetComponent<GameState>();
	}

	public void RegisterP1GuiText(GUIText text) {
		mP1GuiText = text;
		text.text = "P1 Score: = 0";
	}

	public void RegisterP2GuiTExt(GUIText text) {
		mP2GuiText = text;
		text.text = "P2 Score: = 0";
	}

	public void UpdateP1GuiText() {
		mP1GuiText.text = "P1 Score: " + mGameState.Player1Score;
	}

	public void UpdateP2GuiText() {
		mP2GuiText.text = "P2 Score: " + mGameState.Player2Score;
	}

	
	#region Inherited functions
	protected override void DestroyIfMoreThanOneOnObject(){
		if (transform.GetComponents<InputManager>().Length > 1){
			Debug.Log ("Destroying Extra " + this.GetType() + " Attachment");
			DestroyImmediate(this);
		}
	}
	
	#endregion
}





