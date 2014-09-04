using UnityEngine;
using System.Collections;

public class PlayGame : MonoBehaviour {

	void Start(){
		if (!transform.GetComponent<SpriteRenderer> ().enabled) {
			transform.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void OnLevelWasLoaded(int level) {
		Debug.Log ("Loaded");
		transform.GetComponent<SpriteRenderer> ().enabled = true;
		
	}
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)){
			SingletonObject.Get.getGameState().LoadLevel(1);
		}
	}
}
