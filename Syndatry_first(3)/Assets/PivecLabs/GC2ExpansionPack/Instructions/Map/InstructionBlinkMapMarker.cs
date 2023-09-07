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
[Title("Blink Map Markers")]
[Description("Blink Map Markers")]
[Category("Map/Blink Map Markers")]

    [Keywords("Map", "Minimap", "FullMap", "Map Markers")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionBlinkMapMarker : Instruction
{

     
        [SerializeField]
		public GameObject mapMarkerGameobject;
		private Transform markerObject;

		public float repeatEvery;

		public override string Title => "Blink Map Marker";


		protected override async Task Run(Args args)
		{
			markerObject = mapMarkerGameobject.gameObject.transform.Find("MapMarkerImage");
	
			if (markerObject != null)
			{
					await Blink();
			}

        }

		private async Task Blink()
		{
			MeshRenderer renderer = markerObject.GetComponent<MeshRenderer>();

			while (markerObject != null && Application.isPlaying)
			{
				if (renderer.enabled == true)
				{
					renderer.enabled = false;
					await this.Time(repeatEvery);
				}


				else
				{
					renderer.enabled = true;
					await this.Time(repeatEvery);
				}

			}

		}

	}
}