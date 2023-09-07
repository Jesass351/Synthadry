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

    [Title("Inactivate Game Objects by Tag")]
    [Description("Inactivate all game objects scene instance with Tag")]

    [Category("Game Objects/Inactivate Game Objects by Tag")]

    [Keywords("Inactivate", "gameobject", "tag")]
    [Image(typeof(IconCubeOutline), ColorTheme.Type.Red, typeof(OverlayMinus))]

    [Serializable]
    public class InstructionInactivateObjectsByTag : Instruction
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => "Inactivate All Game Objects by Tag";
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
                       go.SetActive(false);
                 }

            return DefaultResult;
        }
    }
}