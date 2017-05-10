using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {

	public AudioClip[] audioClip;
	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

	public void playOnce(int index) {
		this.audioSource.PlayOneShot (audioClip [index]);
	}

	public void playLoop(int index) {
		this.audioSource.Stop ();
		this.audioSource.loop = true;
		this.audioSource.clip = audioClip [index];
		this.audioSource.Play ();
	}

	public void stopAudio() {
		this.audioSource.Stop ();
	}
}
