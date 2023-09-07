using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("3D Textmesh Outline")]
    [Description("Change 3D Textmesh Outline")]
    [Category("TextMesh3D/3D Textmesh Outline")]

    [Parameter("targetObject", "The Game Object with a 3D TMP added")]
 
    [Keywords("TextMesh", "3D", "text", "Color", "Outline")]
    [Image(typeof(IconUIText), ColorTheme.Type.Yellow)]
  

    [Serializable]

    public class Instruction3DTMPOutline : Instruction
    {

	    [SerializeField] private GameObject targetObject;
        private TMPro.TextMeshPro textdata;

        [SerializeField] private PropertyGetColor m_Color = GetColorColorsBlue.Create;
        [SerializeField] public float width;

        public override string Title => "3D Textmesh Outline";


		protected override Task Run(Args args)
	    {
           
            textdata = targetObject.GetComponent<TMPro.TextMeshPro>();

           
                textdata.outlineColor = this.m_Color.Get(args);

                textdata.outlineWidth = width;
           

            textdata.fontSharedMaterial.EnableKeyword("OUTLINE_ON");
            textdata.ForceMeshUpdate();

            return DefaultResult;
        }
     

            
   
		
	}
}