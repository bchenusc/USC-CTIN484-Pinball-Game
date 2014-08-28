using UnityEngine;
using System.Collections;

public class Deadzone : MonoBehaviour {

	public enum DeadZonePlayer {
		Player1,
		Player2
	}

	public DeadZonePlayer myPlayer = DeadZonePlayer.Player1;
	private GameState mGameState;

	void Start() {
		mGameState = SingletonObject.Get.getGameState();
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.CompareTag("Ball")) {
			if (myPlayer == DeadZonePlayer.Player1) {
				// Add score to player 2
				mGameState.Player1Score += 1;
			} else {
				// Add score to player 1
				mGameState.Player2Score += 1;
			}
			Destroy(c.gameObject);
		}
	}
}
