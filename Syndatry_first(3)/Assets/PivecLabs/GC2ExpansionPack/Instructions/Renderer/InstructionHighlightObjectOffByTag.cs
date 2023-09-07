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
    [Title("Highlight Object Off by Tag")]
    [Description("Highlight Object Off by Tag")]
    [Category("Renderer/Highlight Object Off by Tag")]

    [Parameter("targetObject", "The Tag of Game Objects to be Highlighted Off")]
 
    [Keywords("Renderer", "Object", "Highlight")]
    [Image(typeof(IconSphereSolid), ColorTheme.Type.Yellow)]

    [Serializable]

    public class InstructionHighlightObjectOffByTag : Instruction
    {

        [SerializeField] private TagValue m_Tag = new TagValue();
        private GameObject[] target;
        private Renderer[] renderers;
        private Material highlightMaskMaterial;
        private Material highlightFillMaterial;
        private string tagStr = "";

        private static HashSet<Mesh> registeredMeshes = new HashSet<Mesh>();

        public override string Title => "Highlight Object Off by Tag";


		protected override Task Run(Args args)
		{
            tagStr = this.m_Tag.Value;
            GameObject[] target = GameObject.FindGameObjectsWithTag(tagStr);

            if (target != null)
			{



				for (int i = 0; i < target.Length; i++)

				{
					renderers = target[i].GetComponentsInChildren<Renderer>();

					foreach (var renderer in renderers)
					{

						var materials = renderer.sharedMaterials.ToList();

						materials.RemoveAll(x => x.name == "FillObject (Instance)");
						materials.RemoveAll(x => x.name == "MaskObject (Instance)");

						renderer.materials = materials.ToArray();


					}

				}


			}
		
            return DefaultResult;
        }

    
    }
}