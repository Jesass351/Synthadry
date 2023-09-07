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
[Title("Rotate MiniMap Frame")]
[Description("Rotate MiniMap Frame")]
[Category("Map/Rotate MiniMap Frame")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionRotateFrame : Instruction
{

        [SerializeField] private bool RotateFrame;
  
        public override string Title => "Rotate MiniMap Frame";


		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

            if (RotateFrame == true)
            {
                mapmanager.GetComponent<MapManager>().rotating = true;
                mapmanager.GetComponentInChildren<FrameRotate>().rotatingFrame = true;
                mapmanager.GetComponentInChildren<PointerRotate>().rotatingPointer = false;

            }

            if (RotateFrame == false)
            {
                mapmanager.GetComponent<MapManager>().rotating = false;
                mapmanager.GetComponentInChildren<FrameRotate>().rotatingFrame = false;
                mapmanager.GetComponentInChildren<PointerRotate>().rotatingPointer = true;

            }




            return DefaultResult;
        }
		
	}
}