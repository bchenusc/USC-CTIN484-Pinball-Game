using UnityEngine;
using System.Collections;

public class FadeLoading : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SingletonObject.Get.getTimer ().Add ("fadeLoading", Fade, 4, false);
	}

    void Fade(){
		Destroy (gameObject);
	}
}
