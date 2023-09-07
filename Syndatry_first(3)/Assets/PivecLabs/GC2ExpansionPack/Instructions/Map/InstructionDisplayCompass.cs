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
[Title("Activate or Deactivate Compass")]
[Description("Activate or Deactivate Compass")]
[Category("Map/Activate or Deactivate Compass")]

    [Keywords("Map", "Minimap", "FullMap", "Compass")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionDisplayCompass : Instruction
{

        [SerializeField] private bool ActivateCompass;
  
        public override string Title => "Activate or Deactivate Compass";

   
        protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

            if (ActivateCompass == true)
            {
                mapmanager.GetComponent<MapManager>().showCompass = true;
              }

            if (ActivateCompass == false)
            {
                mapmanager.GetComponent<MapManager>().hideCompass = true;
            }

            return DefaultResult;
        }
		
	}
}