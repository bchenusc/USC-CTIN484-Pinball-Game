using UnityEngine;
using System.Collections;

public class ToggleBooster : MonoBehaviour {

	bool isEnabled = true;

	void Start() {
		isEnabled = true;
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (isEnabled && c.gameObject.CompareTag("Ball")) {
			Rigidbody2D otherBody = c.gameObject.rigidbody2D;
			otherBody.velocity = Vector2.zero;
			otherBody.angularVelocity = 0;
			otherBody.AddForce(transform.up * Random.Range(2000, 3000));
			// TODO: Change color here

			isEnabled = false;
			SingletonObject.Get.getTimer().Add(gameObject.GetInstanceID() + "toggleBoosterOn", ToggleBoosterOn, 30, false);
		}
	}

	public void ToggleBoosterOn() {
		isEnabled = true;
	}

}