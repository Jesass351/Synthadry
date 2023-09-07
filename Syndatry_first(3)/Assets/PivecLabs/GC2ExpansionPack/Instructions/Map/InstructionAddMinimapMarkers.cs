using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Add MiniMap Markers")]
[Description("Add MiniMap Markers")]
[Category("Map/Add MiniMap Markers")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionAddMinimapMarkers : Instruction
{
 
        public override string Title => "Add MiniMap Markers";

		[Range(0, 5)]
		public float markerSize = 0.2f;
		public int cullingLayer;

		[System.Serializable]
		public class Marker
		{
			public string Tag;
			public Texture2D Image;
		}

		[SerializeField]
		public List<Marker> MapMarkers = new List<Marker>();






		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

			for (int i = 0; i < MapMarkers.Capacity; i++)
			{


				var gameobject = GameObject.FindGameObjectsWithTag(MapMarkers[i].Tag);
				if (gameobject != null)
				{
					for (int a = 0; a < gameobject.Length; a++)
					{

						GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
						var collide = plane.GetComponent<MeshCollider>();
						collide.convex = true;
						plane.name = "MapMarkerImage";
						plane.transform.localScale = new Vector3(markerSize, markerSize, markerSize);
						plane.transform.parent = gameobject[a].transform;
						plane.transform.position =  new Vector3(gameobject[a].transform.position.x, 10, gameobject[a].transform.position.z);
						plane.layer = cullingLayer;
						Material material = new Material(Shader.Find("Unlit/Transparent Cutout"));
						material.mainTexture = MapMarkers[i].Image;
						plane.GetComponent<Renderer>().material = material;

					}

				}

			}



			return DefaultResult;
        }
		
	}
}