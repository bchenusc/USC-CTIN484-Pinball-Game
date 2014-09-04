﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public enum PaddleType {
		LEFT,
		RIGHT
	}

	public PaddleType mPaddleType = PaddleType.LEFT;

	private float mFPaddleRest;
	private float mFPaddlePressed;
	private InputManager mInputManager;
	private HingeJoint2D mHingeJoint;
	private JointMotor2D mJointMotor;

	private int mMotorPowerUp = 777;
	bool isPlayer1 = true;

	void Start(){
		// Singleton Registration
		mInputManager = SingletonObject.Get.getInputManager();
		mInputManager.RegisterOnKeyHeld(Flip);
		mInputManager.RegisterOnKeyUp (UnFlip);
		// Variable Registration
		// Requirement: Player object is the parent.
		// Spring and Hinge joint initialization
		mHingeJoint = transform.GetComponent<HingeJoint2D> ();
		mHingeJoint.connectedAnchor = new Vector2(transform.parent.position.x,
		                                          transform.parent.position.y);
		mPaddleType = transform.parent.name.Equals("RHinge") ? PaddleType.RIGHT : PaddleType.LEFT;
		isPlayer1 = transform.CompareTag("Player1");
		if (isLeftPaddle()) {
			mHingeJoint.anchor = new Vector2(0.1f, mHingeJoint.anchor.y);
			mFPaddleRest = 0f;
			mFPaddlePressed = 60f;
		} else {
			mFPaddleRest = -60f;
			mFPaddlePressed = 0f;
			mHingeJoint.anchor = new Vector2(-0.1f, mHingeJoint.anchor.y);
		}
		mHingeJoint.useMotor = false;
		mHingeJoint.useLimits = true;
		JointAngleLimits2D jointLimits = mHingeJoint.limits;

		jointLimits.min = mFPaddleRest;
		jointLimits.max = mFPaddlePressed;
		mHingeJoint.limits = jointLimits;
		mJointMotor = mHingeJoint.motor;
		mHingeJoint.motor = mJointMotor;

	}
	
	void Flip(KeyCode key) {
			if (isPlayer1) {
			// PLAYER 1
			if (isLeftPaddle()) {
				// LEFT PADDLE
				if (key == mInputManager.p1Left){
//					
						mJointMotor.motorSpeed = mMotorPowerUp;
						mHingeJoint.motor = mJointMotor;
//					}
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
		if (isPlayer1){
			// LEFT PADDLE
			if(isLeftPaddle()) {
				if (key == mInputManager.p1Left){
					if (mHingeJoint == null) mHingeJoint = transform.GetComponent<HingeJoint2D> ();
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

	bool isLeftPaddle() {
		if (mPaddleType == PaddleType.LEFT) {
			return true;
		} else {
			return false;
		}
	}

	void OnDestroy() {
		mInputManager.DeregisterOnKeyHeld(Flip);
		mInputManager.DeregisterOnKeyUp(UnFlip);
	}
}












