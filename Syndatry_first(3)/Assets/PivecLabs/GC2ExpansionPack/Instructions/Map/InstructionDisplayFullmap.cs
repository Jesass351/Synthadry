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
[Title("Activate or Deactivate FullMap")]
[Description("Activate or Deactivate FullMap")]
[Category("Map/Activate or Deactivate FullMap")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionDisplayFullmap : Instruction
{

        [SerializeField] private bool ActivateFullMap;
        [Range(1, 1500)]
        [SerializeField]
        public float cameraSize = 20f;
        [SerializeField]
        public bool occlusionCulling = true;
        [SerializeField]
        public bool lockMap;
 
        public override string Title => "Activate or Deactivate FullMap";


		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

            if (ActivateFullMap == true)
            {
                mapmanager.GetComponent<MapManager>().showFull = true;
                mapmanager.GetComponent<MapManager>().cameraSizeF = cameraSize;
                mapmanager.GetComponent<MapManager>().occlusionCullingfm = occlusionCulling;
                mapmanager.GetComponent<MapManager>().lockMap = lockMap;

            }


            if (ActivateFullMap == false)
            {
                mapmanager.GetComponent<MapManager>().hideFull = true;

            }




            return DefaultResult;
        }
		
	}
}