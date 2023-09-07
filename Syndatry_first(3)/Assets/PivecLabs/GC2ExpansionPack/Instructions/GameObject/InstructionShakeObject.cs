using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Shake an Object")]
    [Description("Shake an Object")]
    [Category("Game Objects/Shake an Object")]

    [Parameter("targetObject", "The Game Object to Shake")]
 
    [Keywords("Object", "Float", "Floating")]
    [Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]


    [Serializable]

    public class InstructionShakeObject : Instruction
    {

	    [SerializeField] private GameObject targetObject;
	    private GameObject shaker;

         [SerializeField] public float shake_x = (0.01f);
        [SerializeField] public float shake_y = (0.01f);
        [SerializeField] public float shake_z = (0.01f);
        [SerializeField] public float LoopCount = (0f);
        [SerializeField] public bool InfiniteLoops;
        private float loopsCounted = 1;
        private bool Up;
        private bool shaking;
 
        public override string Title => "Shake an Object";


		protected override async Task Run(Args args)
	    {
            shaker = targetObject;
            shaking = true;
            await Shaking();
         
        }


        private async Task Shaking()
        {
            while (shaking == true && Application.isPlaying)
            {
                if (Up)
                {
                    shaker.transform.Translate(shake_x, shake_y, shake_z);
                    Up = false;
                }
                else
                {
                    shaker.transform.Translate(-shake_x, -shake_y, -shake_z);
                    Up = true;
                }

                loopsCounted++;

            if ((LoopCount < loopsCounted) && (InfiniteLoops == false))
            {
                    shaking = false;
            }
	            await this.NextFrame();
            }

           
        }




    }
}