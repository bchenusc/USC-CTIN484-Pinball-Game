using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {

	float force = 1000f;

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.CompareTag("Ball")) {
			c.gameObject.rigidbody2D.
				AddForce(force * (c.transform.position - transform.position));
		}
	}
}
