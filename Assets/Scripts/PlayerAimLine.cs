using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerAimLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private readonly string enemyLayerString = "EnemyLayer";
	private readonly float maxDistance = 50f;
	private int hitLayer;

	void Start() {
		lineRenderer = GetComponent<LineRenderer> ();
	}

	void Update() {
		RaycastHit hit;
		hitLayer = LayerMask.GetMask (enemyLayerString);
		if (Physics.Raycast (transform.position, transform.up, out hit, maxDistance, hitLayer)) {
			lineRenderer.SetPosition (0, transform.position);
			lineRenderer.SetPosition (1, hit.point);
		} else {
			lineRenderer.SetPosition (0, transform.position);
			lineRenderer.SetPosition (1, transform.position + transform.up *  maxDistance);
		}
	}
}
