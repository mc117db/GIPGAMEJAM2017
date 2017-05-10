using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlinkingEffect : MonoBehaviour {

	private Color mainColor;
	private float recoverRate = 10f;

	void Start() {
		mainColor = GetComponent<SpriteRenderer> ().color;
	}

	void Update() {
		mainColor.a = Mathf.Lerp (mainColor.a, 1f, recoverRate * Time.deltaTime);
	}

	void blinkOnce() {
		mainColor.a = 0.1f;
	}

	void blinkMultiple() {
		StartCoroutine (blinkMultipleEffects ());
	}

	IEnumerator blinkMultipleEffects() {
		for (int n = 0; n < 5; n++) {
			mainColor.a = 0.1f;
			yield return new WaitForSeconds (0.1f);
		}
		yield return null;
	}
}
