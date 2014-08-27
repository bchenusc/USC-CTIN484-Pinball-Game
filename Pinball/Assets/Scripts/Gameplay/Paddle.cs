using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public enum PaddleType {
		LEFT,
		RIGHT
	}

	public Player playerScript;
	public PaddleType paddleType = PaddleType.LEFT;
	private Player.PlayerType playerType;

	private Transform mHinge;

	void Start(){
		// Quick way to get the player. Just make the player the parent.
		// Paddle -> Hinge -> LPaddle -> Player
		playerScript = transform.parent.parent.parent.GetComponent<Player>();
		// Get your hinge to rotate around.
		mHinge = transform.parent;
		// Register yourself with the Input manager.
		SingletonObject.Get.getInputManager().RegisterOnKeyHeld(Flip);

	}

	void Flip() {
		if (paddleType == PaddleType.LEFT) {
			if (Input.GetKey(playerScript.left_control)){
				// Left paddle flip calculations.
			}
		} else {
			if (paddleType == PaddleType.RIGHT) {
				if (Input.GetKey(playerScript.left_control)){
					// Right paddle flip calculations.
				}
			}
		}
	}
}

















