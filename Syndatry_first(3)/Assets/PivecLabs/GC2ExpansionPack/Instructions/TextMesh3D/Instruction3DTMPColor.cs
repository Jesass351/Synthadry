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
    [Title("3D Textmesh Color")]
    [Description("Change 3D Textmesh Color")]
    [Category("TextMesh3D/3D Textmesh Color")]

    [Parameter("targetObject", "The Game Object with a 3D TMP added")]
 
    [Keywords("TextMesh", "3D", "text", "Color")]
    [Image(typeof(IconUIText), ColorTheme.Type.Yellow)]
  

    [Serializable]

    public class Instruction3DTMPColor : Instruction
    {

	    [SerializeField] private GameObject targetObject;
        private TMPro.TextMeshPro textdata;

        [SerializeField] private PropertyGetColor m_Color = GetColorColorsBlue.Create;

        public override string Title => "3D Textmesh Color";


		protected override Task Run(Args args)
	    {
           
            textdata = targetObject.GetComponent<TMPro.TextMeshPro>();

           textdata.color = this.m_Color.Get(args);

            textdata.ForceMeshUpdate();

            return DefaultResult;
        }
     

            
   
		
	}
}