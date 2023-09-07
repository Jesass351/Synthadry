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
[Title("Position MiniMap")]
[Description("Position MiniMap")]
[Category("Map/Position MiniMap")]

    [Keywords("Map", "Minimap", "FullMap")]
    [Image(typeof(IconCharacterWalk), ColorTheme.Type.Red)]


    [Serializable]

	public class InstructionPositionMinimap : Instruction
{

        [SerializeField]
        public enum MAPPOSITION
        {
            TopRight,
            TopLeft,
            BottomLeft,
            BottomRight

        }
        [SerializeField]
        public MAPPOSITION mapPosition = MAPPOSITION.TopRight;

        [SerializeField] private bool Resize;
        [SerializeField] private float WidthMultiplyer;
        [SerializeField] private float offsetX;
        [SerializeField] private float offsetY;
        private RectTransform m_RectTransform;
        public override string Title => "Position MiniMap";


		protected override Task Run(Args args)
		{
            GameObject mapmanager = GameObject.Find("MapManager");

              switch (mapPosition)
            {
                case MAPPOSITION.BottomLeft:
                    mapmanager.GetComponent<MapManager>().mapPosition = 1;
                    break;
                case MAPPOSITION.TopLeft:
                    mapmanager.GetComponent<MapManager>().mapPosition = 2;
                    break;
                case MAPPOSITION.TopRight:
                    mapmanager.GetComponent<MapManager>().mapPosition = 3;
                    break;
                case MAPPOSITION.BottomRight:
                    mapmanager.GetComponent<MapManager>().mapPosition = 4;
                    break;

            }

            if (Resize == true)
            {
                mapmanager.GetComponent<MapManager>().resized = true;
                mapmanager.GetComponent<MapManager>().resizeamount = WidthMultiplyer;

            }

            if (offsetX != 0)
                mapmanager.GetComponent<MapManager>().mmoffsetx = offsetX;

            if (offsetY != 0)
                mapmanager.GetComponent<MapManager>().mmoffsety = offsetY;

            return DefaultResult;
        }
		
	}
}