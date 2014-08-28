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

	public int mMotorPowerUp = 1000;

	private Vector2 position2D;

	void Start(){
		// Singleton Registration
		mInputManager = SingletonObject.Get.getInputManager();
		mInputManager.RegisterOnKeyHeld(Flip);
		mInputManager.RegisterOnKeyUp (UnFlip);
		// Variable Registration
		// Requirement: Player object is the parent.
		position2D = new Vector2 (transform.position.x, transform.position.y);
		mPlayerScript = transform.parent.parent.GetComponent<Player>();
		// Spring and Hinge joint initialization
		mFPaddleStr = 10f;
		mFPaddleDamper = 1f;
		mHingeJoint = transform.GetComponent<HingeJoint2D> ();
		mHingeJoint.useMotor = true;
		mHingeJoint.useLimits = true;
		JointAngleLimits2D jointLimits = mHingeJoint.limits;
		//transform.rotation = Quaternion.AngleAxis (180, Vector3.forward);
		if (isLeftPaddle()) {
			mFPaddleRest = 0f;
			mFPaddlePressed = 45f;
		} else {
			mFPaddleRest = -45f;
			mFPaddlePressed = 0f;
			mHingeJoint.anchor = new Vector2(-0.1f, mHingeJoint.anchor.y);
		}
		mHingeJoint.connectedAnchor = new Vector2(transform.parent.position.x,
		                                          transform.parent.position.y);
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
					mJointMotor.motorSpeed = mMotorPowerUp;
					mHingeJoint.motor = mJointMotor;
				}
			} else {
				// RIGHT PADDLE
				if (key == mInputManager.p1Right){
					mJointMotor.motorSpeed = -mMotorPowerUp;
					mHingeJoint.motor = mJointMotor;
				}
			}
		} else {
			// PLAYER 2
			if (isLeftPaddle()) {
				// LEFT PADDLE
				if (key == mInputManager.p2Left){
					mJointMotor.motorSpeed = mMotorPowerUp;
					mHingeJoint.motor = mJointMotor;
				} 
			} else {
				// RIGHT PADDLE
				if (key == mInputManager.p2Right){
					mJointMotor.motorSpeed = -mMotorPowerUp;
					mHingeJoint.motor = mJointMotor;
				}
			}
		}
	}

	void UnFlip(KeyCode key) {
		if (isPlayer1()){
			// LEFT PADDLE
			if(isLeftPaddle()) {
				if (key == mInputManager.p1Left){
					mJointMotor.motorSpeed = -mMotorPowerUp;
					mHingeJoint.motor = mJointMotor;
				} 
			}
			else {
				// RRIGHT PADDLE
				if (key == mInputManager.p1Right){
					// Player 1 Right Paddle
					mJointMotor.motorSpeed = mMotorPowerUp;
					mHingeJoint.motor = mJointMotor;
				}
			}
		} else {
			if (isLeftPaddle()) {
				// LEFT PADDLE
				if (key == mInputManager.p2Left){
					mJointMotor.motorSpeed = -mMotorPowerUp;
					mHingeJoint.motor = mJointMotor;
				} 
			} else {
				// RIGHT PADDLE
				if (key == mInputManager.p2Right){
					mJointMotor.motorSpeed = mMotorPowerUp;
					mHingeJoint.motor = mJointMotor;
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












