using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace PivecLabs.GameCreator.VisualScripting
{

	[CustomPropertyDrawer(typeof(InstructionCustomTimerSeconds))]

public class InstructionCustomTimerSecondsDrawer : PropertyDrawer
{
	
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUILayout.PropertyField(property.FindPropertyRelative("m_Seconds"), new GUIContent("Seconds Timer"));
		EditorGUILayout.Space();
		EditorGUILayout.PropertyField(property.FindPropertyRelative("executeOnFinish"));
		var onFinish = property.FindPropertyRelative("executeOnFinish");

		if (onFinish.boolValue == true)
		{
			EditorGUI.indentLevel++;

			EditorGUILayout.PropertyField(property.FindPropertyRelative("result"), new GUIContent("Call after Finished"));

			switch (property.FindPropertyRelative("result").intValue)
			{
			case 0:
				EditorGUILayout.PropertyField(property.FindPropertyRelative("actionToCall"), new GUIContent("Action to Call"));
				break;
			case 1:
				EditorGUILayout.PropertyField(property.FindPropertyRelative("conditionToCall"), new GUIContent("Condition to Call"));
				break;

			}
			
			EditorGUI.indentLevel--;
			
		}
  
		}
	
	

}
}