using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace PivecLabs.GameCreator.VisualScripting
{

	[CustomPropertyDrawer(typeof(InstructionRandomInstructionFromList))]

public class InstructionRandomInstructionFromListDrawer : PropertyDrawer
{
	
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUILayout.LabelField("Instruction List");
		var m_Property = property.FindPropertyRelative("ListOfActions");
		ArrayGUI(m_Property, "Instruction ", true);
		EditorGUILayout.Space();
		EditorGUILayout.PropertyField(property.FindPropertyRelative("m_WaitToFinish"));
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