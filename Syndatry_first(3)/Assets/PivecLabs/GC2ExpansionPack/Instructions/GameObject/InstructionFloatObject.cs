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
    [Title("Float an Object")]
    [Description("Float an Object")]
    [Category("Game Objects/Float an Object")]

    [Parameter("targetObject", "The Game Object to be Floated")]
 
    [Keywords("Object", "Float", "Floating")]
    [Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]


    [Serializable]

    public class InstructionFLoatObject : Instruction
    {

	    [SerializeField] private GameObject targetObject;
	    private GameObject floater;

        private float tempValy;
        private float tempValx;
        private float tempValz;
        private Vector3 objPos;

        [SerializeField] private float amplitude_y = (0.01f);
        [SerializeField] private float speed_y = (1.0f);
        [SerializeField] private float amplitude_x = (0.01f);
        [SerializeField] private float speed_x = (5.0f);
        [SerializeField] private float amplitude_z = (0.01f);
        [SerializeField] private float speed_z = (5.0f);
         [SerializeField] private float LoopCount = (0f);
        [SerializeField] private bool InfiniteLoops;
        private float loopsCounted = 1;
        private bool floating;
        public override string Title => "Float an Object";


		protected override async Task Run(Args args)
	    {
            floater = targetObject;
            floating = true;
            await Floating();
         
        }


        private async Task Floating()
        {
            while (floating== true && Application.isPlaying)
            {          
            tempValy = floater.transform.position.y;
            tempValx = floater.transform.position.x;
            tempValz = floater.transform.position.z;

            objPos.y = tempValy + amplitude_y * Mathf.Sin(speed_y * UnityEngine.Time.time);
            objPos.x = tempValx + amplitude_x * Mathf.Sin(speed_x * UnityEngine.Time.time);
            objPos.z = tempValz + amplitude_z * Mathf.Sin(speed_z * UnityEngine.Time.time);
            floater.transform.position = objPos;

            loopsCounted++;

            if ((LoopCount < loopsCounted) && (InfiniteLoops == false))
            {
                    floating = false;
            }
	            await this.Time(0.01f);
            }

           
        }




    }
}