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
[Title("Position Compass")]
[Description("Position Compass")]
[Category("Map/Position Compass")]

    [Keywords("Map", "Minimap", "FullMap", "Compass")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionPositionCompass : Instruction
{

        [SerializeField]
        public enum COMPASSPOSITION
        {
            Top,
            Bottom

        }
        [SerializeField]
        public COMPASSPOSITION compassPosition = COMPASSPOSITION.Top;

         [SerializeField] private float offsetY;
    
        public override string Title => "Position Compass";


		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

              switch (compassPosition)
            {
                case COMPASSPOSITION.Top:
                    mapmanager.GetComponent<MapManager>().compassPosition = 1;
                    break;
                case COMPASSPOSITION.Bottom:
                    mapmanager.GetComponent<MapManager>().compassPosition = 2;
                    break;
              
            }


            if (offsetY != 0)
                mapmanager.GetComponent<MapManager>().cmoffsety = offsetY;

   

            return DefaultResult;
        }
		
	}
}