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
    [Title("3D Textmesh Size")]
    [Description("Change 3D Textmesh Size")]
    [Category("TextMesh3D/3D Textmesh Size")]

    [Parameter("targetObject", "The Game Object with a 3D TMP added")]
 
    [Keywords("TextMesh3D", "3D", "text", "Size")]
    [Image(typeof(IconUIText), ColorTheme.Type.Yellow)]
  

    [Serializable]

    public class Instruction3DTMPSize : Instruction
    {

	    [SerializeField] private GameObject targetObject;
        private TMPro.TextMeshPro textdata;

        [SerializeField] private PropertyGetInteger m_Size = new PropertyGetInteger(12);
        [SerializeField] public bool textAutoSize = false;

        public override string Title => "3D Textmesh Size";


		protected override Task Run(Args args)
	    {
           
            textdata = targetObject.GetComponent<TMPro.TextMeshPro>();

            if (textAutoSize == false)
            {
                textdata.autoSizeTextContainer = false;
                textdata.fontSize = (float)this.m_Size.Get(args);
            }

            else
            {
                textdata.autoSizeTextContainer = true;
            }
            textdata.ForceMeshUpdate();

            return DefaultResult;
        }
     

            
   
		
	}
}