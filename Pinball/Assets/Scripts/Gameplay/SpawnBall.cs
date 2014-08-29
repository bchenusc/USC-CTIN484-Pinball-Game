using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

	public Transform prefab;

	// Use this for initialization
	void Start () {
		fire ();
		SingletonObject.Get.getTimer ().Add("ballspawner", 
		                                    fire, 1, true);
	}
	
	void fire() {
		Transform clone = Instantiate(prefab, transform.position, Quaternion.identity) as Transform;
		clone.rigidbody2D.AddForce(new Vector2(Random.Range(-2f, 2.0f), Random.Range(-.1f,-1f)) * 100);
	}
}
