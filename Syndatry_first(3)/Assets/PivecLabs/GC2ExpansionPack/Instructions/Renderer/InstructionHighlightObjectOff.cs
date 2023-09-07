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

    [Version(1, 0, 1)]
    [Title("Highlight Object Off")]
    [Description("Highlight Object Off")]
    [Category("Renderer/Highlight Object Off")]

    [Parameter("targetObject", "The Game Object to be Highlighted")]
 
    [Keywords("Renderer", "Object", "Highlight")]
    [Image(typeof(IconSphereSolid), ColorTheme.Type.Yellow)]

    [Serializable]

    public class InstructionHighlightObjectOff : Instruction
    {
   
        [SerializeField] private PropertyGetGameObject targetObject;

        private Renderer[] renderers;
        private Material highlightMaskMaterial;
        private Material highlightFillMaterial;

        private static HashSet<Mesh> registeredMeshes = new HashSet<Mesh>();

        public override string Title => "Highlight Object Off";


		protected override Task Run(Args args)
		{
            GameObject target = this.targetObject.Get(args);
            if (target != null)
            {
                renderers = target.GetComponentsInChildren<Renderer>();


                foreach (var renderer in renderers)
                {

                    var materials = renderer.sharedMaterials.ToList();

                    materials.RemoveAll(x => x.name == "FillObject (Instance)");
                    materials.RemoveAll(x => x.name == "MaskObject (Instance)");

                    renderer.materials = materials.ToArray();


                }

            }
            return DefaultResult;
        }

    
    }
}