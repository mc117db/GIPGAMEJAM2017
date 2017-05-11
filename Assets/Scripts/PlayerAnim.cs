using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

	private Animator anim;
	private bool isSoggy = false;

	/*
	public bool IsSoggy {
		get{
			return isSoggy;
		}
		set {
			if (value) {
				anim.SetBool ("isSoggy", true);
			} else {
				anim.SetBool ("isSoggy", false);
			}
			isSoggy = value;
		}
	}
	*/

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void Update() {
		if (isSoggy) {
			anim.SetBool ("isSoggy", true);
		} else {
			anim.SetBool ("isSoggy", false);
		}
	}


}
