//	GameObjectComments.cs
//	Dylan Yates
//	v1.0

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GameObjectComments : MonoBehaviour {
#if UNITY_EDITOR
	public string comment = "";
	public int fontSize = 11;
	public int colorSelectedIndex = 0;

	void Start() {
		if (gameObject.GetComponents(typeof(GameObjectComments)).Length > 1) {
			Debug.Log ("Only one instance of GameObjectComments can be added to a GameObject");
			DestroyImmediate (this);
		}
	}
#endif
}
