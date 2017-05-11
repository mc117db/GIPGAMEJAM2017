using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovements : MonoBehaviour {

	[Range(1f, 7f)]public float moveSpeedMin = 0.5f;
	[Range(1f, 7f)]public float moveSpeedMax = 1f;
	[Range(1f, 7f)]public float turnDelayMin = 0.5f;
	[Range(1f, 7f)]public float turnDelayMax = 0.9f;
	[Range(0f, 5f)]public float sizeMin = 0.8f;
	[Range(0f, 5f)]public float sizeMax = 1.3f;

	protected GameObject player;
	private readonly string playerTagName = "Player";
	private readonly float speedDamp = 0.5f;
	protected readonly float movePower = 100f;
	protected float moveSpeed;
	protected float turnDelay;
	private float size;

	protected bool canMove;
	protected Rigidbody2D rbody;
	private float targetRotation;

	void Awake() {
		rbody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag (playerTagName);

	}

	void Start() {
		moveSpeed = Random.Range (moveSpeedMin, moveSpeedMax);
		turnDelay = Random.Range (turnDelayMin, turnDelayMax);
		size = Random.Range (moveSpeedMin, sizeMax);
		canMove = true;
		//rbody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		limitMovement ();
		turnToPlayer ();
		if (canMove) {
			moveToPlayer ();
		}
	}

	void turnToPlayer() {
		Vector3 vecDiff = player.transform.position - this.transform.position;
		float angle = Mathf.Atan2 (vecDiff.y, vecDiff.x) * Mathf.Rad2Deg;
		Quaternion targetRotation = Quaternion.AngleAxis (angle - 90f, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnDelay);
	}

	void moveToPlayer() {
		rbody.AddForce (transform.up * movePower * Time.deltaTime);
		//transform.Translate (transform.InverseTransformDirection(transform.right) * moveSpeed * Time.deltaTime);
	}

	void limitMovement() {
		if (rbody.velocity.magnitude > moveSpeed) {
			Vector2 newSpeed = rbody.velocity.normalized * moveSpeed;
			rbody.velocity = Vector2.Lerp (rbody.velocity, newSpeed, speedDamp);
		} 
	}

	public void stopMovement() {
		this.canMove = false;
	}
}
