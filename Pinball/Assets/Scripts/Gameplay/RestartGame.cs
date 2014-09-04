using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	void OnMouseDown(){
		SingletonObject.Get.getGameState ().ResetScore ();
		SingletonObject.Get.getGameState ().LoadLevel (0);
	}
}
