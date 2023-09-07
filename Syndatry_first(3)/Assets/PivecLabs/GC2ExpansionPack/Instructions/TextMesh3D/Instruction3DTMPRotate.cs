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
    [Title("3D Textmesh Rotate")]
    [Description("Change 3D Textmesh Rotate")]
    [Category("TextMesh3D/3D Textmesh Rotate")]

    [Parameter("targetObject", "The Game Object with a 3D TMP added")]
 
    [Keywords("TextMesh", "3D", "text", "Rotate")]
    [Image(typeof(IconUIText), ColorTheme.Type.Yellow)]
  

    [Serializable]

    public class Instruction3DTMPRotate : Instruction
    {

	    [SerializeField] private PropertyGetGameObject targetObject;
  
        [SerializeField] private PropertyGetGameObject lookAt = GetGameObjectTransform.Create();

        public override string Title => "3D Textmesh Rotate";


	    protected override Task Run(Args args)
	    {
           
		    GameObject gameObjecttmp = this.targetObject.Get(args);
		    GameObject gameObjectT = this.lookAt.Get(args);
		    if (gameObjecttmp != null)
		    
			      gameObjecttmp.transform.rotation = Quaternion.LookRotation(gameObjecttmp.transform.position - gameObjectT.transform.position);

		    return DefaultResult;
        }
     
		
	}
}