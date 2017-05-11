using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBugMovement : EnemyMovements {

	[Range(0f, 5f)][SerializeField]private float moveDuration;
	[Range(0f, 5f)][SerializeField]private float moveInterval;

	void Start() {
		InvokeRepeating ("move", moveInterval, moveInterval);
	}

	private void stopImmediately() {
		canMove = false;
		rbody.velocity = new Vector2 (0, 0);
	}

	private void move() {
		StartCoroutine (moveSingleStep());
	}

	IEnumerator moveSingleStep () {
		Vector3 vecDiff = player.transform.position - this.transform.position;
		float angle = Mathf.Atan2 (vecDiff.y, vecDiff.x) * Mathf.Rad2Deg;
		Quaternion targetRotation = Quaternion.AngleAxis (angle - 90f, Vector3.forward);
		transform.rotation = targetRotation;

		canMove = true;
		rbody.AddForce (transform.up * movePower * 500f * Time.deltaTime);
		yield return new WaitForSeconds (moveDuration);
		stopImmediately ();
	}
}
