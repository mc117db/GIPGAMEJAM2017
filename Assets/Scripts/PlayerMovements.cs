using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {

	[SerializeField][Range(0f, 200f)]private float movementSpeed = 50f;
	[SerializeField][Range(0f, 10f)]private float maxSpeed = 2f;
	[SerializeField]private float stoppingDamp = 5f;

	private readonly float speedDamp = 0.5f;
	private Rigidbody2D rbody;

	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		if (!PlayerInputs.leftButtonDown && !PlayerInputs.rightButtonDown &&
			!PlayerInputs.upButtonDown && !PlayerInputs.downButtonDown) {
			rbody.drag = stoppingDamp;
		} else {
			rbody.drag = 0;
		}
	}

	void FixedUpdate () {
		if (PlayerInputs.leftButtonDown) {
			rbody.AddForce (new Vector2(-movementSpeed, 0));
		}
		if (PlayerInputs.rightButtonDown) {
			rbody.AddForce (new Vector2(movementSpeed, 0));
		}
		if (PlayerInputs.upButtonDown) {
			rbody.AddForce (new Vector2(0, movementSpeed));
		}
		if (PlayerInputs.downButtonDown) {
			rbody.AddForce (new Vector2(0, -movementSpeed));
		}

		limitMovementSpeed ();
	}

	void limitMovementSpeed() {
		if (rbody.velocity.magnitude > maxSpeed) {
			Vector2 newSpeed = rbody.velocity.normalized * maxSpeed;
			rbody.velocity = Vector2.Lerp (rbody.velocity, newSpeed, speedDamp);
		} 
	}
}
