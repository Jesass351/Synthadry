using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;
using PivecLabs.CustomTagSelector;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(0, 0, 1)]
    
    [Title("Destroy Game Objects by Tag")]
    [Description("Destroys all game objects scene instance with Tag")]

    [Category("Game Objects/Destroy Game Objects by Tag")]

    [Keywords("Remove", "Delete", "Flush", "MonoBehaviour", "Behaviour", "Script")]
    [Image(typeof(IconCubeOutline), ColorTheme.Type.Red, typeof(OverlayMinus))]
    
    [Serializable]
    public class InstructionDestroyObjectsByTag : Instruction
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => "Destroy All Game Objects by Tag";
        [SerializeField] [TagSelector] public string tagStr = "";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override Task Run(Args args)
        {
  
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tagStr);

            if (objects.Length < 1)
            {
                 return DefaultResult;
            }

            foreach (GameObject go in objects)
            {
                UnityEngine.Object.Destroy(go);
            }
            return DefaultResult;
        }
    }
}