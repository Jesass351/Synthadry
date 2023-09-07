namespace PivecLabs.GameCreator.VisualScripting
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.UI;
	using UnityEditor;

	[ExecuteInEditMode]

	[CustomEditor(typeof(MapManager))]
	
	public class MapManagerEditor : Editor 
	{
	

		SerializedProperty mapPanel;
		SerializedProperty rawImage;
		SerializedProperty mapCanvas;
		SerializedProperty Compasscanvas;
		SerializedProperty CompassImage;
		SerializedProperty CompassDirectionText;


		void OnEnable()
		{

		
			mapPanel = serializedObject.FindProperty("mapPanel");
			rawImage = serializedObject.FindProperty("rawImage");
			mapCanvas = serializedObject.FindProperty("mapCanvas");

	
			Compasscanvas = serializedObject.FindProperty("Compasscanvas");
			CompassImage = serializedObject.FindProperty("CompassImage");
			CompassDirectionText = serializedObject.FindProperty("CompassDirectionText");

  

		}

		public override void OnInspectorGUI()
		{
			
			serializedObject.Update();
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("MAP MANAGER",EditorStyles.whiteLargeLabel);
			EditorGUILayout.Space(); EditorGUI.indentLevel++;
			EditorGUILayout.PropertyField(mapCanvas, new GUIContent("MAP Canvas"));
			EditorGUILayout.PropertyField(mapPanel, new GUIContent("MAP Panel"));
			EditorGUILayout.PropertyField(rawImage, new GUIContent("Raw Image"));
			EditorGUILayout.Space(); 
			EditorGUILayout.PropertyField(Compasscanvas, new GUIContent("Compass Canvas"));
			EditorGUILayout.PropertyField(CompassImage, new GUIContent("Compass Image"));
			EditorGUILayout.PropertyField(CompassDirectionText, new GUIContent("Compass Heading"));
			EditorGUI.indentLevel--;
			EditorGUILayout.Space();
		

			serializedObject.ApplyModifiedProperties();
		}
		
#if UNITY_EDITOR

		public static void AddAlwaysIncludedShader(string shaderName)
		{
	    	
			var shader = Shader.Find(shaderName);
			if (shader == null)
				return;
			SerializedObject graphicsSettings = new SerializedObject(AssetDatabase.LoadAssetAtPath<UnityEngine.Object>("ProjectSettings/GraphicsSettings.asset"));
			var arrayProp = graphicsSettings.FindProperty("m_AlwaysIncludedShaders");
			bool hasShader = false;
			for (int i = 0; i < arrayProp.arraySize; ++i)
			{
				var arrayElem = arrayProp.GetArrayElementAtIndex(i);
				if (shader == arrayElem.objectReferenceValue)
				{
					hasShader = true;
					break;
				}
			}
 
			if (!hasShader)
			{
				int arrayIndex = arrayProp.arraySize;
				arrayProp.InsertArrayElementAtIndex(arrayIndex);
				var arrayElem = arrayProp.GetArrayElementAtIndex(arrayIndex);
				arrayElem.objectReferenceValue = shader;
 
				graphicsSettings.ApplyModifiedProperties();
 
				AssetDatabase.SaveAssets();
			    
				Debug.Log("Shader Added");
			}
		    
		   
		}
	    
		
	   #endif
	}
}