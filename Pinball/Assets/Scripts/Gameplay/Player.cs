using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum PlayerType {
		PLAYER_1,
		PLAYER_2
	}
	public PlayerType myPlayer = PlayerType.PLAYER_1;

	Queue children = new Queue();

	void Awake() {
		// Tag all my children as player 1.
		string newTag = myPlayer == PlayerType.PLAYER_1 ? "Player1" : "Player2";
		transform.tag = newTag;
		foreach (Transform t in transform) {
			// Add all immediate children to the queue.
			children.Enqueue(t);
		}
		while (children.Count != 0) {
			Transform t = (Transform)children.Dequeue();
			t.tag = newTag;
			foreach (Transform c in t) {
				children.Enqueue(c);
			}
		}
	}
}
