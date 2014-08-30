using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.CompareTag("Ball")) {
			Rigidbody2D otherBody = c.gameObject.rigidbody2D;
			otherBody.velocity = Vector2.zero;
			otherBody.angularVelocity = 0;
			otherBody.AddForce(transform.up * Random.Range (1000, 2000)); 
		}
	}
}
