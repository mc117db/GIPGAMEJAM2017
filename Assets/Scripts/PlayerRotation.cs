﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
public class PlayerRotation : MonoBehaviour {

	[SerializeField]private Texture2D cursorImage;

	void Start() {
       // Cursor.visible = true;
	//	Cursor.lockState = CursorLockMode.Confined;
	}

	void Update() {
		if (PlayerInputs.canMove) {
			Vector2 vectorDiff = Camera.main.ScreenToWorldPoint (PlayerInputs.mousePos) - transform.position;
			transform.up = vectorDiff;
		}
	}
}
