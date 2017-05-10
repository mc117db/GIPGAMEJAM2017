using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour {

	[HideInInspector]public bool canMove;

	[HideInInspector]public static bool upButtonDown;
	[HideInInspector]public static bool downButtonDown;
	[HideInInspector]public static bool leftButtonDown;
	[HideInInspector]public static bool rightButtonDown;
	[HideInInspector]public static bool spaceButtonPressed;
	[HideInInspector]public static bool leftMouseDown;
	[HideInInspector]public static bool rightMouseDown;

	private bool prevLeftDown = false;
	private bool prevRightDown = false;

	void Start() {
		canMove = true;
	}

	void Update () {
		if (canMove) {
			upButtonDown = Input.GetKey (KeyCode.W);
			downButtonDown = Input.GetKey (KeyCode.S);
			leftButtonDown = Input.GetKey (KeyCode.A);
			rightButtonDown = Input.GetKey (KeyCode.D);
			spaceButtonPressed = Input.GetKeyDown (KeyCode.Space);
			checkMouseButton ();
		}
	}

	// deals with mouse button inputs.
	// if both mouse buttons are held down, check which one is the last to held down.
	private void checkMouseButton() {
		if (Input.GetKey (KeyCode.Mouse0) && Input.GetKey (KeyCode.Mouse1)) {
			if (prevLeftDown == false && prevRightDown == true) {
				leftMouseDown = prevLeftDown = prevRightDown = true;
				rightMouseDown = false;
			} else if (prevLeftDown == true && prevRightDown == false) {
				rightMouseDown = prevRightDown = prevLeftDown = true;
				leftMouseDown = false;
			} else if (prevLeftDown == false && prevRightDown == false) {
				// if player happen to press both mouse button in same frame, we pick left button.
				leftMouseDown = prevLeftDown = prevRightDown = true;
				rightMouseDown = false;
			} else {
				return;
			}
		} else {
			if (Input.GetKey (KeyCode.Mouse0) && !Input.GetKey (KeyCode.Mouse1)) {
				leftMouseDown = prevLeftDown = true;
				rightMouseDown = prevRightDown = false;
			} else if (Input.GetKey (KeyCode.Mouse1) && !Input.GetKey (KeyCode.Mouse0)) {
				leftMouseDown = prevLeftDown = false;
				rightMouseDown = prevRightDown = true;
			} else {
				leftMouseDown = rightMouseDown = prevLeftDown = prevRightDown = false;
			}
		}
	}
}
