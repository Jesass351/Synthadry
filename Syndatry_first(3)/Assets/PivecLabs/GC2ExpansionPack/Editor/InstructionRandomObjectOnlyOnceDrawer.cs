using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace PivecLabs.GameCreator.VisualScripting
{

	[CustomPropertyDrawer(typeof(InstructionRandomObjectOnlyOnce))]

public class InstructionRandomObjectOnlyOnceDrawer : PropertyDrawer
{
	
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUILayout.LabelField("Object List");
		var m_Property = property.FindPropertyRelative("ListofObjects");
		ArrayGUI(m_Property, "Object ", true);
		EditorGUILayout.Space();
		EditorGUILayout.PropertyField(property.FindPropertyRelative("active"),new GUIContent("Set Active/Inactive"));
		
		EditorGUILayout.PropertyField(property.FindPropertyRelative("leaveactive"),new GUIContent("Leave Active/Inactive"));
		EditorGUILayout.Space();
  
		}
	
	private void ArrayGUI(SerializedProperty property, string itemType, bool visible)
	{

		{

			SerializedProperty arraySizeProp = property.FindPropertyRelative("Array.size");
			EditorGUILayout.PropertyField(arraySizeProp);
             
			for (int i = 0; i < arraySizeProp.intValue; i++)
			{
				EditorGUILayout.PropertyField(property.GetArrayElementAtIndex(i), new GUIContent(itemType + (i +1).ToString()), true);
				}		
		}
	}

}
}