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
[Title("Add Single MiniMap Marker")]
[Description("Add Single MiniMap Marker")]
[Category("Map/Add Single MiniMap Marker")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionAddSingleMinimapMarkers : Instruction
{
 
        public override string Title => "Add Single MiniMap Marker";

		[Range(0, 5)]
		public float markerSize = 0.2f;
		public int cullingLayer;

		public Texture2D Image;

		[SerializeField]
		public GameObject mapMarkerGameobject;






		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

	
				
				if (mapMarkerGameobject != null)
				{
					

						GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
						var collide = plane.GetComponent<MeshCollider>();
						collide.convex = true;
						plane.name = "MapMarkerImage";
						plane.transform.localScale = new Vector3(markerSize, markerSize, markerSize);
						plane.transform.parent = mapMarkerGameobject.transform;
						plane.transform.position =  new Vector3(mapMarkerGameobject.transform.position.x, 10, mapMarkerGameobject.transform.position.z);
						plane.layer = cullingLayer;
						Material material = new Material(Shader.Find("Unlit/Transparent Cutout"));
						material.mainTexture = Image;
						plane.GetComponent<Renderer>().material = material;

					
				}

		



			return DefaultResult;
        }
		
	}
}