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

    [Title("Activate Game Objects by Tag")]
    [Description("Activate all game objects scene instance with Tag")]

    [Category("Game Objects/Activate Game Objects by Tag")]

    [Keywords("Activate", "gameobject", "tag")]
    [Image(typeof(IconCubeOutline), ColorTheme.Type.Red)]

    [Serializable]
    public class InstructionActivateObjectsByTag : Instruction
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => "Activate All Game Objects by Tag";
        [SerializeField] [TagSelector] public string tagStr = "";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override Task Run(Args args)
        {
            Transform[] objects = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].CompareTag(tagStr))
                {
                    objects[i].gameObject.SetActive(true);
                }
            }

            return DefaultResult;
        }

    }
}