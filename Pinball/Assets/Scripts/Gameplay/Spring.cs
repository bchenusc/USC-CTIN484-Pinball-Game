using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.CompareTag("Ball")) {
			c.gameObject.rigidbody2D.AddForce(Vector3.up * 5000);
		}
	}
}
