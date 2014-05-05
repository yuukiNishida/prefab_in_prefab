﻿using UnityEngine;
using UnityEditor;
using System.Collections;

namespace PrefabInPrefab
{

[CustomEditor(typeof(PrefabInPrefab))]
public class PrefabInPrefabEditor : Editor {
	private SerializedProperty prefab;
	private SerializedProperty moveComponents;
	private SerializedProperty previewInEditor;

	void OnEnable()
	{
		prefab = serializedObject.FindProperty("prefab");
		moveComponents = serializedObject.FindProperty("moveComponents");
		previewInEditor = serializedObject.FindProperty("previewInEditor");
	}

	public override void OnInspectorGUI() {
		serializedObject.Update();
		prefab.objectReferenceValue = (GameObject)EditorGUILayout.ObjectField("Prefab", prefab.objectReferenceValue, typeof(GameObject), false);
		moveComponents.boolValue = EditorGUILayout.Toggle("Move Components", moveComponents.boolValue);
		previewInEditor.boolValue = EditorGUILayout.Toggle("Preview In Editor", previewInEditor.boolValue);
		serializedObject.ApplyModifiedProperties();
	}
}

}
