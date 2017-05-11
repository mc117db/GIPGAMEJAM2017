using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerAimLine : MonoBehaviour {

	private LineRenderer lineRenderer;
	private readonly string enemyLayerString = "Enemy";
	private readonly float maxDistance = 50f;
	private int hitLayer;
	private bool isSoggy;

	/*
	public bool IsSoggy {
		get{
			return isSoggy;
		}
		set {
			if (value) {
				RaycastHit hit;
				hitLayer = LayerMask.GetMask (enemyLayerString);
				if (Physics.Raycast (transform.position, transform.up, out hit, maxDistance, hitLayer)) {
					lineRenderer.SetPosition (0, transform.position);
					lineRenderer.SetPosition (1, hit.point);
				} else {
					lineRenderer.SetPosition (0, transform.position);
					lineRenderer.SetPosition (1, transform.position + transform.up * maxDistance);
				}
			} else {
				lineRenderer.SetPosition (0, transform.position);
				lineRenderer.SetPosition (1, transform.position);
			}
			isSoggy = value;
		}
	}
	*/

	void Start() {
		lineRenderer = GetComponent<LineRenderer> ();
	}

	void Update() {
		if (isSoggy) {
			RaycastHit hit;
			hitLayer = LayerMask.GetMask (enemyLayerString);
			if (Physics.Raycast (transform.position, transform.up, out hit, maxDistance, hitLayer)) {
				lineRenderer.SetPosition (0, transform.position);
				lineRenderer.SetPosition (1, hit.point);
			} else {
				lineRenderer.SetPosition (0, transform.position);
				lineRenderer.SetPosition (1, transform.position + transform.up * maxDistance);
			}
		} else {
			lineRenderer.SetPosition (0, transform.position);
			lineRenderer.SetPosition (1, transform.position);
		}
	}
}
