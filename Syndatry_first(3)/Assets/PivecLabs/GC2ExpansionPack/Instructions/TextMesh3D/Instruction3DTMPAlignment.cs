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
    [Title("3D Textmesh Alignment")]
    [Description("Change 3D Textmesh Alignment")]
    [Category("TextMesh3D/3D Textmesh Alignment")]

    [Parameter("targetObject", "The Game Object with a 3D TMP added")]
 
    [Keywords("TextMesh", "3D", "text", "Alignment")]
    [Image(typeof(IconUIText), ColorTheme.Type.Yellow)]
  

    [Serializable]

    public class Instruction3DTMPAlignment : Instruction
    {

	    [SerializeField] private GameObject targetObject;
        private TMPro.TextMeshPro textdata;

        public enum ALIGN
        {
            Left,
            Center,
            Right,
            Justified
        }
        [SerializeField] public ALIGN alignment = ALIGN.Left;


        public override string Title => "3D Textmesh Alignment";


		protected override Task Run(Args args)
	    {
            textdata = targetObject.GetComponent<TMPro.TextMeshPro>();

            switch (this.alignment)
            {
                case ALIGN.Left:
                    textdata.alignment = TMPro.TextAlignmentOptions.Left;
                    break;
                case ALIGN.Center:
                    textdata.alignment = TMPro.TextAlignmentOptions.Center;
                    break;
                case ALIGN.Right:
                    textdata.alignment = TMPro.TextAlignmentOptions.Right;
                    break;
                case ALIGN.Justified:
                    textdata.alignment = TMPro.TextAlignmentOptions.Justified;
                    break;
            }


            textdata.ForceMeshUpdate();
            return DefaultResult;
        }
     

            
   
		
	}
}