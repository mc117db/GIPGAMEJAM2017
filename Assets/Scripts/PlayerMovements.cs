using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInputs))]
public class PlayerMovements : MonoBehaviour {

	[SerializeField][Range(0f, 200f)]private float movementPower = 50f;
	[SerializeField][Range(0f, 10f)]private float maxSpeed = 2f;
	[SerializeField][Range(0f, 100f)]private float stoppingDamp = 5f;

	[Space(10)]
	[SerializeField]private float minX = -7.8f;
	[SerializeField]private float maxX = 7.8f;
	[SerializeField]private float minY = -5f;
	[SerializeField]private float maxY = 5f;

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
		transform.position = new Vector2 (Mathf.Clamp(transform.position.x, minX, maxX),
			Mathf.Clamp(transform.position.y, minY, maxY));
		if (PlayerInputs.leftButtonDown) {
			rbody.AddForce (new Vector2(-movementPower, 0));
		}
		if (PlayerInputs.rightButtonDown) {
			rbody.AddForce (new Vector2(movementPower, 0));
		}
		if (PlayerInputs.upButtonDown) {
			rbody.AddForce (new Vector2(0, movementPower));
		}
		if (PlayerInputs.downButtonDown) {
			rbody.AddForce (new Vector2(0, -movementPower));
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
