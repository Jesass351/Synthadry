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
[Title("Drag Fullscreen Map")]
[Description("Drag Fullscreen Map")]
[Category("Map/Drag Fullscreen Map")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionDragMap : Instruction
{

        [SerializeField]
        public bool dragMapOnOff;
        public enum DRAGBUTTON
        {
            Left,
            Middle,
            Right

        }
        [SerializeField]
        public DRAGBUTTON dragButton = DRAGBUTTON.Left;
         [SerializeField]
        [Range(1, 10)]
        public int dragSpeed = 1;
 

        public override string Title => "Drag Fullscreen Map";


		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");
            mapmanager.GetComponent<MapManager>().dragMap = dragMapOnOff;
            mapmanager.GetComponent<MapManager>().dragspeed = dragSpeed;
            switch (dragButton)
            {
                case DRAGBUTTON.Left:
                    mapmanager.GetComponent<MapManager>().dragbutton = 0;
                    break;
                case DRAGBUTTON.Middle:
                    mapmanager.GetComponent<MapManager>().dragbutton = 2;
                    break;
                case DRAGBUTTON.Right:
                    mapmanager.GetComponent<MapManager>().dragbutton = 1;
                    break;
             
            }


            return DefaultResult;
        }
		
	}
}