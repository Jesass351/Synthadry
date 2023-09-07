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
[Title("Zoom Fullscreen Map")]
[Description("Zoom Fullscreen Map")]
[Category("Map/Zoom Fullscreen Map")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionZoomMap : Instruction
{

     
        [SerializeField]
        public bool zoomMapOnOff;
        [SerializeField]
        [Range(1f, 20f)]
        public float scrollwheelSensitivity = 5.0f;

        public override string Title => "Zoom Fullscreen Map";


		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");
            mapmanager.GetComponent<MapManager>().zoomMap = zoomMapOnOff;
            mapmanager.GetComponent<MapManager>().zoomSensitivity = scrollwheelSensitivity;


            return DefaultResult;
        }
		
	}
}