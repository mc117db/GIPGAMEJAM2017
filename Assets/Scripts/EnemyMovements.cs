using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour {

	public float moveSpeedMin = 0.5f;
	public float moveSpeedMax = 1f;
	public float turnDelayMin = 0.5f;
	public float turnDelayMax = 0.9f;
	public float sizeMin = 0.8f;
	public float sizeMax = 1.3f;

	private GameObject player;
	private readonly string playerTagName = "Player";
	private float moveSpeed;
	private float turnDelay;
	private float size;

	private bool canMove;
	private float targetRotation;

	void Start() {
		player = GameObject.FindGameObjectWithTag (playerTagName);
		moveSpeed = Random.Range (moveSpeedMin, moveSpeedMax);
		turnDelay = Random.Range (turnDelayMin, turnDelayMax);
		size = Random.Range (moveSpeedMin, sizeMax);
		canMove = true;
	}

	void FixedUpdate() {
		if (canMove) {
			turnToPlayer ();
			moveToPlayer ();
		}
	}

	void turnToPlayer() {
		Vector3 vecDiff = player.transform.position - this.transform.position;
		float angle = Mathf.Atan2 (vecDiff.y, vecDiff.x) * Mathf.Rad2Deg;
		Quaternion targetRotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnDelay);
	}

	void moveToPlayer() {
		transform.Translate (transform.InverseTransformDirection(transform.right) * moveSpeed * Time.deltaTime);
	}

}
