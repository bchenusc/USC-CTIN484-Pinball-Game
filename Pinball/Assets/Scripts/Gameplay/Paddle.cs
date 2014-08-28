using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public enum PaddleType {
		LEFT,
		RIGHT
	}

	public Player mPlayerScript;
	public PaddleType mPaddleType = PaddleType.LEFT;

	private float mFPaddleRest;
	private float mFPaddlePressed;
	private float mFPaddleStr;
	private float mFPaddleDamper;
	private InputManager mInputManager;
	private HingeJoint2D mHingeJoint;
	private JointMotor2D mJointMotor;

	void Start(){
		// Singleton Registration
		mInputManager = SingletonObject.Get.getInputManager();
		mInputManager.RegisterOnKeyHeld(Flip);
		mInputManager.RegisterOnKeyUp (UnFlip);
		// Variable Registration
		// Requirement: Player object is the parent.
		mPlayerScript = transform.parent.GetComponent<Player>();
		// Spring and Hinge joint initialization
		mFPaddleRest = 0f;
		mFPaddlePressed = 45f;
		mFPaddleStr = 10f;
		mFPaddleDamper = 1f;
		mHingeJoint = transform.GetComponent<HingeJoint2D> ();
		mHingeJoint.useMotor = true;
		mHingeJoint.useLimits = true;
		JointAngleLimits2D jointLimits = mHingeJoint.limits;
		jointLimits.min = mFPaddleRest;
		jointLimits.max = mFPaddlePressed;
		mHingeJoint.limits = jointLimits;
		mJointMotor = mHingeJoint.motor;
		mHingeJoint.motor = mJointMotor;
	}
	
	void Flip(KeyCode key) {
		if (isPlayer1()) {
			// PLAYER 1
			if (isLeftPaddle()) {
				// LEFT PADDLE
				if (key == mInputManager.p1Left){
					Debug.Log("Flip p1 left");
					mJointMotor.motorSpeed = 1000;
					mHingeJoint.motor = mJointMotor;
				}
			} else {
				// RIGHT PADDLE
				if (key == mInputManager.p1Right){
					mJointMotor.motorSpeed = 1000;
				}
			}
		} else {
			// PLAYER 2
			if (isLeftPaddle()) {
				// LEFT PADDLE
				if (key == mInputManager.p2Left){
					mJointMotor.motorSpeed = 1000;
				} 
			} else {
				// RIGHT PADDLE
				if (key == mInputManager.p2Right){
					mJointMotor.motorSpeed = 1000;
				}
			}
		}
	}

	void UnFlip(KeyCode key) {
		if (isPlayer1()) {
			// PLAYER 1
			if (isLeftPaddle()) {
				// LEFT PADDLE
				if (key == mInputManager.p1Left){
					Debug.Log("Unflip P1 Left");
					mJointMotor.motorSpeed = -1000;
					mHingeJoint.motor = mJointMotor;
				}
			} else {
				// RRIGHT PADDLE
				if (key == mInputManager.p1Right){
					// Player 1 Right Paddle
					mJointMotor.motorSpeed = -1000;
				}
			}
		} else {
			// PLAYER 2
			if (isLeftPaddle()) {
				// LEFT PADDLE
				if (key == mInputManager.p2Left){
					mJointMotor.motorSpeed = -1000;
				} 
			} else {
				// RIGHT PADDLE
				if (key == mInputManager.p2Right){
					mJointMotor.motorSpeed = -1000;
				}
			}
		}
	}

	bool isPlayer1() {
		if (mPlayerScript.myPlayer == Player.PlayerType.PLAYER1) {
			return true;
		} else {
			return false;
		}
	}

	bool isLeftPaddle() {
		if (mPaddleType == PaddleType.LEFT) {
			return true;
		} else {
			return false;
		}
	}
}












