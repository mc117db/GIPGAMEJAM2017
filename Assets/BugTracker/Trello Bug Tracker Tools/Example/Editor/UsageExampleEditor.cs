using UnityEngine;
using System.Collections;
using UnityEditor;
using TrelloAPI;

[CustomEditor(typeof(UsageExample))]
public class UsageExampleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        UsageExample myScript = (UsageExample)target;
        EditorGUILayout.HelpBox("Use, optionally, to verify your connection in play mode", MessageType.Info);
        if (GUILayout.Button("Check Connection") && EditorApplication.isPlaying)
        {
            myScript.StartCoroutine(myScript.Start());
        }
    }
}
