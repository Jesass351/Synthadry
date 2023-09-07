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
    [Title("3D Textmesh Font")]
    [Description("Change 3D Textmesh Font")]
    [Category("TextMesh3D/3D Textmesh Font")]

    [Parameter("targetObject", "The Game Object with a 3D TMP added")]
 
    [Keywords("TextMesh", "3D", "text", "Font")]
    [Image(typeof(IconUIText), ColorTheme.Type.Yellow)]
  

    [Serializable]

    public class Instruction3DTMPFont : Instruction
    {

	    [SerializeField] private GameObject targetObject;
        private TMPro.TextMeshPro textdata;

        [SerializeField] public TMPro.TMP_FontAsset font;


        public override string Title => "3D Textmesh Font";


		protected override Task Run(Args args)
	    {
           
            textdata = targetObject.GetComponent<TMPro.TextMeshPro>();

            if (this.font != null)
                textdata.font = font;

            textdata.ForceMeshUpdate();

            return DefaultResult;
        }
     

            
   
		
	}
}