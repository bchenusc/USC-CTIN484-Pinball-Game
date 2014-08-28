using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	void Start() {
		// Register with GuiManager.
		if (transform.parent.CompareTag("Player1")) {
			SingletonObject.Get.getGuiManager().RegisterP1GuiText(
				transform.GetComponent<GUIText>());
		}
		else {
			SingletonObject.Get.getGuiManager().RegisterP2GuiTExt(
				transform.GetComponent<GUIText>());
		}
	}
}
