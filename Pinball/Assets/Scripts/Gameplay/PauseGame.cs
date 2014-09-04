using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	private bool isPaused = false;

	void Start() {
		isPaused = false;
	}

	void OnMouseDown(){
		if (!isPaused) {
			// Pauses the game and changes the pause button's color to red.
			transform.GetComponent<SpriteRenderer> ().color = Color.red;
			SingletonObject.Get.getGameState().PauseGame();
			isPaused = true;
		} else {
			transform.GetComponent<SpriteRenderer> ().color = Color.white;
			SingletonObject.Get.getGameState().ResumeGame();
			isPaused = false;
		}

	}
}
