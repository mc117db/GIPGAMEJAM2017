using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextAnimate : MonoBehaviour {

    [Range(0f, 500f)][SerializeField] private float animateSpeed = 30f;

    [SerializeField] private string[] textList;

    private Text text;
    private int textIndex = 0;
    private int charIndex = 0;
	
	void Start() {
        text = GetComponent<Text>();
		StartCoroutine (playText());

    }
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			if(charIndex < textList[textIndex].Length) {
				charIndex = textList[textIndex].Length;
			} else if(textIndex < textList.Length -1) {
				textIndex++;
				charIndex = 0;
                StartCoroutine(playText());
			} else if(textIndex >= textList.Length -1) {
                // TODO close text box smoothly.
                gameObject.SetActive(false);
            }
		}
	}
	
	IEnumerator playText() {
		while(true) {
			yield return new WaitForSeconds(1/animateSpeed);
			if(charIndex > textList[textIndex].Length) {
				break;
			} else {
				text.text = textList[textIndex].Substring(0, charIndex);
				charIndex++;
			}
		}
	}
}
