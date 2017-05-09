#if UNITY_EDITOR

//	GameObjectCommentsEditor.cs
//	Dylan Yates
//	v1.0

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

[CustomEditor(typeof(GameObjectComments))]
public class GameObjectCommentsEditor : Editor {

	string comment = "";
	GUIStyle style = new GUIStyle();
	GUILayoutOption[] options = new GUILayoutOption[] {GUILayout.ExpandHeight(true),GUILayout.ExpandWidth(true)};
	int fontSize = 11;
	int colorSelectedIndex = 0;
	string[] colors = new string[] {"Black", "White", "Grey", "Red", "Blue", "Green", "Yellow", "Orange", "Purple", "Cyan"};

	// Used for Undo operations
	string previousComment = "";
	int previousFontSize = 11;
	int previousColorSelectedIndex = 0;

	void OnEnable() {

		UnityEditorInternal.ComponentUtility.MoveComponentUp((Component)target); // Keep the comments at the top

		// Make the default text color white when using Unity Pro
		if (EditorGUIUtility.isProSkin) {
			style.normal.textColor = Color.white;
		}

		style.richText = true;  // Only use rich text when not editing
		style.wordWrap = true;

		comment = ((GameObjectComments)target).comment;
	}

	public override void OnInspectorGUI() {

		comment = ((GameObjectComments)target).comment;
		comment = EditorGUILayout.TextArea(comment, style, options); // Draw the text area
		// Record undo object when the text has changed
		if (comment.Equals(previousComment) == false) {
			Undo.RecordObject(target, "Comment Edit");
			previousComment = comment;
		}
		((GameObjectComments)target).comment = comment;

		if (EditorGUIUtility.editingTextField) { // Show options when editing
			style.richText = false; // Show rich text tags

			GUILayout.BeginHorizontal();
			// Bold button
			if(GUILayout.Button("Bold")) {
				GUIUtility.keyboardControl = 0;
				Undo.RecordObject(target, "Bold Tag");
				comment = comment + "<b></b>";
				((GameObjectComments)target).comment = comment;
			}

			// Italics button
			if(GUILayout.Button("Italics")) {
				GUIUtility.keyboardControl = 0;
				Undo.RecordObject(target, "Italics Tag");
				comment = comment + "<i></i>";
				((GameObjectComments)target).comment = comment;
			}
			GUILayout.EndHorizontal();

			// Size button and text field
			GUILayout.BeginHorizontal();
			GUILayout.Label ("Size");

			fontSize = ((GameObjectComments)target).fontSize;
			fontSize = EditorGUILayout.IntField(fontSize); // Text box for font size
			if (fontSize != previousFontSize) { // Record object if the font size has changed
				Undo.RecordObject(target, "Font Size");
				previousFontSize = fontSize;
			}
			((GameObjectComments)target).fontSize = fontSize;

			GUILayout.Space(Screen.width / 10);

			if(GUILayout.Button("Add size tag")) {
				GUIUtility.keyboardControl = 0;
				Undo.RecordObject(target, "Size Tag");
				comment = comment + "<size=" + fontSize + "></size>";
				((GameObjectComments)target).comment = comment;
			}
			GUILayout.EndHorizontal();


			// Color button and drop down
			GUILayout.BeginHorizontal();
			GUILayout.Label ("Color");

			colorSelectedIndex = ((GameObjectComments)target).colorSelectedIndex;
			colorSelectedIndex = EditorGUILayout.Popup(colorSelectedIndex, colors); // Drop down menu for colors
			if (colorSelectedIndex != previousColorSelectedIndex) { // Record object if the selected index has changed
				Undo.RecordObject(target, "Color Selection");
				previousColorSelectedIndex = colorSelectedIndex;
			}
			((GameObjectComments)target).colorSelectedIndex = colorSelectedIndex;

			GUILayout.Space(Screen.width / 10);

			if(GUILayout.Button("Add color tag")) {
				GUIUtility.keyboardControl = 0;
				Undo.RecordObject(target, "Color Tag");
				comment = comment + "<color=" + colors[colorSelectedIndex] + "></color>";
				((GameObjectComments)target).comment = comment;
			}
			GUILayout.EndHorizontal();

		} else {
			style.richText = true;
		}
	}

	[MenuItem("GameObject/GameObject Comments")]
	static void AddGameObjectComments() {
		if (Selection.activeGameObject != null) {
			Undo.AddComponent<GameObjectComments>(Selection.activeGameObject);
		} else {
			Debug.LogError("Please select a GameObject before adding the GameObjectComments script");
		}
	}
}
#endif
