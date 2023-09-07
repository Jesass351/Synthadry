using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Highlight an Object on Mouseover by Tag")]
    [Description("Highlight an Object Material on Mouseover by Tag")]
    [Category("Renderer/Highlight an Object on Mouseover by Tag")]

    [Parameter("targetObject", "The Tag of Game Objects to be Highlighted")]

    [Keywords("Renderer", "Object", "Highlight", "Mouseover")]
    [Image(typeof(IconSphereSolid), ColorTheme.Type.Yellow)]

    [Serializable]

    public class InstructionHighlightObjectOnMouseoverByTag : Instruction
    {
        [SerializeField] private TagValue m_Tag = new TagValue();


        private Renderer[] renderers;
        private Material highlightMaskMaterial;
        private Material highlightFillMaterial;
        private string tagStr = "";
        private Mouse mouse;
        private GameObject target;

        [SerializeField] [Range(0.0f, 6.0f)] public float highlightWidth = 1.0f;

        [SerializeField] public Color highlightColour = Color.green;

        private static HashSet<Mesh> registeredMeshes = new HashSet<Mesh>();

        public override string Title => "Highlight an Object on Mouseover by Tag";


        protected override async Task Run(Args args)
        {
            tagStr = this.m_Tag.Value;
            mouse = InputSystem.GetDevice<Mouse>();
            Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
   
                if (hit.transform.gameObject.tag == this.tagStr)
                {
                    target =  hit.transform.gameObject;
                     renderers = target.GetComponentsInChildren<Renderer>();
                    foreach (var skinnedMeshRenderer in target.GetComponentsInChildren<SkinnedMeshRenderer>())
                    {
                        if (registeredMeshes.Add(skinnedMeshRenderer.sharedMesh))
                        {
                            skinnedMeshRenderer.sharedMesh.uv4 = new Vector2[skinnedMeshRenderer.sharedMesh.vertexCount];
                        }
                    }
                    foreach (var meshFilter in target.GetComponentsInChildren<MeshFilter>())
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
                else 
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

            }

	        await this.NextFrame();

        }
    }
}