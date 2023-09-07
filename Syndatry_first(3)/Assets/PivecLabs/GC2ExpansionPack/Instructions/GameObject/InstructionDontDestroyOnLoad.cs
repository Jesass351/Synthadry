using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{
    [Version(0, 0, 1)]
    
    [Title("Dont Destroy On Load")]
    [Description("Stops game object instance from being Destroyed")]

    [Category("Game Objects/Dont Destroy On Load")]

    [Keywords("Remove", "Delete", "Flush", "Destroy")]
    [Image(typeof(IconCubeOutline), ColorTheme.Type.Red, typeof(OverlayMinus))]
    
    [Serializable]
    public class InstructionGameObjectDestroy : Instruction
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        [SerializeField] private PropertyGetGameObject targetObject;

        public override string Title => "Dont Destroy On Load";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override Task Run(Args args)
        {
            GameObject target = this.targetObject.Get(args);
            if (target != null)
            {

                UnityEngine.Object.DontDestroyOnLoad(target);
            }
            return DefaultResult;
        }
    }
}