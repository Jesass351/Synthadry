﻿using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace PivecLabs.GameCreator.VisualScripting
{

	[CustomPropertyDrawer(typeof(InstructionDragObject))]

public class InstructionDragObjectDrawer : PropertyDrawer
{
	
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUILayout.PropertyField(property.FindPropertyRelative("targetObject"));
		EditorGUILayout.Space();
			EditorGUILayout.PropertyField(property.FindPropertyRelative("restrictDragging"));

		var onRestrict = property.FindPropertyRelative("restrictDragging");

		if (onRestrict.boolValue == true)
		{
			EditorGUI.indentLevel++;
			EditorGUILayout.PropertyField(property.FindPropertyRelative("xAxis"));
			EditorGUILayout.PropertyField(property.FindPropertyRelative("yAxis"));
			EditorGUILayout.PropertyField(property.FindPropertyRelative("zAxis"));
			EditorGUI.indentLevel--;
			}
			
			
			
		
  
		}
	
	

}
}