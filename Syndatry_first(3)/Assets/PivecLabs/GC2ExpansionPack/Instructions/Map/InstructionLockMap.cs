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
[Title("Lock Fullscreen Map")]
[Description("Lock Fullscreen Map")]
[Category("Map/Lock Fullscreen Map")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionLockMap : Instruction
{

        [SerializeField] private bool LockMap;
  
        public override string Title => "Lock/UnLock Fullscreen Map";


		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

            if (LockMap == true)
            {
                mapmanager.GetComponent<MapManager>().lockFull = true;

            }

            if (LockMap == false)
            {
                mapmanager.GetComponent<MapManager>().unlockFull = true;

            }




            return DefaultResult;
        }
		
	}
}