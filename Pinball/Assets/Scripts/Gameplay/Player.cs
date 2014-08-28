using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum PlayerType {
		PLAYER1,
		PLAYER2
	}

	public PlayerType myPlayer = PlayerType.PLAYER1;
}
