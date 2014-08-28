using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

	public Transform prefab;

	// Use this for initialization
	void Start () {
		SingletonObject.Get.getTimer ().Add("ballspawner", 
		                                    fire,
		                                    10,
		                                    true);
	}
	
	void fire() {
		Transform clone = Instantiate(prefab, transform.position, Quaternion.identity) as Transform;
		clone.rigidbody2D.AddForce(new Vector2(Random.Range(0,1), Random.Range(0,1)));
	}
}
