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
[Title("Remove Map Marker")]
[Description("Remove Map Marker")]
[Category("Map/Remove Map Marker")]

	[Keywords("Map", "Minimap", "FullMap", "Map Markers")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionRemoveMapMarker : Instruction
{


		[SerializeField]
		public GameObject mapMarkerGameobject;
		private Transform markerObject;

		public override string Title => "Remove Map Marker";


		protected override Task Run(Args args)
		{
			markerObject = mapMarkerGameobject.gameObject.transform.Find("MapMarkerImage");
			if (markerObject != null)
			{
				UnityEngine.Object.Destroy(markerObject.gameObject);
			}

			return DefaultResult;
		}


	}
}