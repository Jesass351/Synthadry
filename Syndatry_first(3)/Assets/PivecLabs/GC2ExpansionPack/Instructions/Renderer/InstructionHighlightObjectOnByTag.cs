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
    [Title("Highlight an Object by Tag")]
    [Description("Highlight an Object Material by Tag")]
    [Category("Renderer/Highlight an Object by Tag")]

    [Parameter("targetObject", "The Tag of Game Objects to be Highlighted")]
 
    [Keywords("Renderer", "Object", "Highlight")]
    [Image(typeof(IconSphereSolid), ColorTheme.Type.Yellow)]

    [Serializable]

    public class InstructionHighlightObjectOnByTag : Instruction
    {
        [SerializeField] private TagValue m_Tag = new TagValue();

 
        private Renderer[] renderers;
        private Material highlightMaskMaterial;
        private Material highlightFillMaterial;
        private string tagStr = "";


        [SerializeField] [Range(0.0f, 6.0f)] public float highlightWidth = 1.0f;

        [SerializeField] public Color highlightColour = Color.green;

        private static HashSet<Mesh> registeredMeshes = new HashSet<Mesh>();

        public override string Title => "Highlight an Object by Tag";


		protected override Task Run(Args args)
		{


           tagStr = this.m_Tag.Value;
              GameObject[] target = GameObject.FindGameObjectsWithTag(tagStr);

            if (target != null)
            {
                for (int i = 0; i < target.Length; i++)
                {
                    renderers = target[i].GetComponentsInChildren<Renderer>();
                    foreach (var skinnedMeshRenderer in target[i].GetComponentsInChildren<SkinnedMeshRenderer>())
                    {
                        if (registeredMeshes.Add(skinnedMeshRenderer.sharedMesh))
                        {
                            skinnedMeshRenderer.sharedMesh.uv4 = new Vector2[skinnedMeshRenderer.sharedMesh.vertexCount];
                        }
                    }
                    foreach (var meshFilter in target[i].GetComponentsInChildren<MeshFilter>())
                    {


                        meshFilter.sharedMesh.SetUVs(3, new Vector2[meshFilter.sharedMesh.vertexCount]);
                    }


                    highlightMaskMaterial = UnityEngine.Object.Instantiate(Resources.Load<Material>(@"MaskObject"));
                    highlightFillMaterial = UnityEngine.Object.Instantiate(Resources.Load<Material>(@"FillObject"));

                    highlightMaskMaterial.name = "MaskObject (Instance)";
                    highlightFillMaterial.name = "FillObject (Instance)";



                    foreach (var renderer in renderers)
                    {

                        var materials = renderer.sharedMaterials.ToList();

                        materials.Add(highlightMaskMaterial);
                        materials.Add(highlightFillMaterial);

                        renderer.materials = materials.ToArray();
                    }

                    highlightFillMaterial.SetColor("_HighLightColor", highlightColour);
                    highlightMaskMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
                    highlightFillMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.LessEqual);
                    highlightFillMaterial.SetFloat("_HighLightWidth", highlightWidth);
                }
            }
            return DefaultResult;
        }

    
    }
}