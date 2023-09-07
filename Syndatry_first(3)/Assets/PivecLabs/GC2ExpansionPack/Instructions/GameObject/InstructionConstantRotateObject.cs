using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Constant Rotate of an Object")]
    [Description("Constant Rotate of an Object")]
    [Category("Game Objects/Constant Rotate of an Object")]

    [Parameter("targetObject", "The Game Object to be Rotated")]

    [Keywords("Object", "Rotate", "Constant")]
    [Image(typeof(IconRotation), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionConstantRotateObject : Instruction
    {



        [SerializeField] private PropertyGetGameObject targetObject;

        [SerializeField] public float rotationSpeed = 100.0f;

        [SerializeField] public bool xAxis = false;
        [SerializeField] public bool yAxis = false;
        [SerializeField] public bool zAxis = false;
        [SerializeField] public bool reverse = false;

        private float xaxis = 0.0f;
        private float yaxis = 0.0f;
        private float zaxis = 0.0f;

        private Vector3 rotateAxis;
        private GameObject objectToRotate;
        public override string Title => "Constant Rotate of an Object";


        protected override async Task Run(Args args)
        {
            objectToRotate = this.targetObject.Get(args);
            if (objectToRotate != null)
            {

                if (xAxis && !reverse) { xaxis = 90.0f; }
                else if (xAxis && reverse) { xaxis = -90.0f; }
                else { xaxis = 0.0f; }

                if (yAxis && !reverse) { yaxis = 90.0f; }
                else if (yAxis && reverse) { yaxis = -90.0f; }
                else { yaxis = 0.0f; }

                if (zAxis && !reverse) { zaxis = 90.0f; }
                else if (zAxis && reverse) { zaxis = -90.0f; }
                else { zaxis = 0.0f; }


                rotateAxis = new Vector3(xaxis, yaxis, zaxis);

            }
            await RunTaskAsync();
        }



        async Task RunTaskAsync()
        {
            while (objectToRotate &&  Application.isPlaying)
            {
                objectToRotate.transform.Rotate(rotateAxis, rotationSpeed * UnityEngine.Time.deltaTime);
	            await this.NextFrame();
            }
        }
    }
}