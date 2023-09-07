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
[Title("Activate or Deactivate MiniMap")]
[Description("Activate or Deactivate MiniMap")]
[Category("Map/Activate or Deactivate MiniMap")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionDisplayMinimap : Instruction
{

        [SerializeField] private bool ActivateMiniMap;
  
        public override string Title => "Activate or Deactivate MiniMap";

        [Range(1, 1500)]
        [SerializeField]
        public float cameraSize = 20f;
        [SerializeField] 
        public bool occlusionCulling = true;


        protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

            if (ActivateMiniMap == true)
            {
                mapmanager.GetComponent<MapManager>().showMini = true;
                mapmanager.GetComponent<MapManager>().cameraSizeM = cameraSize;
                mapmanager.GetComponent<MapManager>().occlusionCullingmm = occlusionCulling;
            }

            if (ActivateMiniMap == false)
            {
                mapmanager.GetComponent<MapManager>().hideMini = true;
            }

            return DefaultResult;
        }
		
	}
}