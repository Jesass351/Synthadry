using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Rotate Fixed Camera Shot")]
    [Description("Rotate Fixed Camera Shot")]
    [Category("Cameras/Rotate Fixed Camera Shot")]

    [Parameter("targetObject", "The Game Object to place the Video on")]
 
    [Keywords("Audio", "Video", "RenderSurface","Camera")]
    [Image(typeof(IconShotFixed), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionRotateFixedCameraShot : Instruction
    {

       [SerializeField] private PropertyGetShot m_Shot = GetShotInstance.Create;

             public enum DIRECTION
        {
            Left,
            Right,
            Up,
            Down
        }

        [SerializeField] public DIRECTION direction = DIRECTION.Left;

        [SerializeField] private float speed = 10f;


        public override string Title => "Rotate Fixed Camera Shot";


		protected override async Task Run(Args args)
		{
           ShotCamera shot = this.m_Shot.Get(args);

            if (shot == null) return;
            ShotTypeFixed shotFixed = shot.ShotType as ShotTypeFixed;
            if (shotFixed == null) return;

            float value = (float)this.speed;
            switch (this.direction)
            {
                case DIRECTION.Left:
                case DIRECTION.Down:
                    value = +value;
                    break;
                case DIRECTION.Right:
                case DIRECTION.Up:
                    value = -value;
                    break;
            }

            if (this.direction == DIRECTION.Left || this.direction == DIRECTION.Right)
                shot.transform.Rotate(Vector3.up, value * UnityEngine.Time.deltaTime);

                       else if (this.direction == DIRECTION.Up || this.direction == DIRECTION.Down)
                shot.transform.Rotate(Vector3.right, value * UnityEngine.Time.deltaTime);

             
			await this.NextFrame();
        }
		
	}
}