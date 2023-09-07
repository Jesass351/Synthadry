using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace PivecLabs.GameCreator.VisualScripting
{

	[CustomPropertyDrawer(typeof(InstructionPlayRandomSFXFromList))]

public class InstructionPlayRandomSFXFromListDrawer : PropertyDrawer
{
		private SerializedProperty array1;
		private SerializedProperty arraySize;
		private void OnGUIHandler()
			{
			EditorGUILayout.LabelField("SFX List");
			EditorGUILayout.Space();	

		}
	


		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			var container = new VisualElement();
			var baseInspector = new IMGUIContainer(OnGUIHandler);
			container.Add(baseInspector);

     		//	arraySize = property.FindPropertyRelative("listSize");
			//	array1 = property.FindPropertyRelative("ListOfSounds");


			//	var arrayInspector = new IMGUIContainer(OnGUIArray);
			//	container.Add(arrayInspector);

			SerializedProperty array = property.FindPropertyRelative("ListOfSounds");
			PropertyField array2 = new PropertyField(array);
			container.Add(array2);


			var m_WaitToFinish = new PropertyField(property.FindPropertyRelative("m_WaitToFinish"));
			container.Add(m_WaitToFinish);

			var audioConfig = new PropertyField(property.FindPropertyRelative("audioConfig"));
			container.Add(audioConfig);

			return container;
		}

	
	}
}