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
[Title("Toggle Map Markers")]
[Description("Toggle Map Markers")]
[Category("Map/Toggle Map Markers")]

    [Keywords("Map", "Minimap", "FullMap", "Map Markers")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionToggleMapMarkers : Instruction
{

     
        [SerializeField]
        public bool mapMarkersOnOff;
       
        public override string Title => "Toggle Map Markers";


		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");
			foreach (GameObject gameObj in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (gameObj.name == "MapMarkerImage")
				{
					gameObj.SetActive(mapMarkersOnOff);

				}
			}



			return DefaultResult;
        }
		
	}
}