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
    [Title("3D Textmesh Content")]
    [Description("Change 3D Textmesh Content")]
    [Category("TextMesh3D/3D Textmesh Content")]

    [Parameter("targetObject", "The Game Object with a 3D TMP added")]
 
    [Keywords("TextMesh", "3D", "text", "Content")]
    [Image(typeof(IconUIText), ColorTheme.Type.Yellow)]
  

    [Serializable]

    public class Instruction3DTMPContent : Instruction
    {

	    [SerializeField] private GameObject targetObject;
        private TMPro.TextMeshPro textdata;

        [SerializeField] public string content = "";

        public override string Title => "3D Textmesh Content";


		protected override Task Run(Args args)
	    {
           
            textdata = targetObject.GetComponent<TMPro.TextMeshPro>();

            textdata.text = this.content;

            textdata.ForceMeshUpdate();

            return DefaultResult;
        }
     

            
   
		
	}
}