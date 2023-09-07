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
    [Version(0, 0, 1)]
    
    [Title("Dont Destroy On Load List")]
    [Description("Stops game object instance from being Destroyed")]

    [Category("Game Objects/Dont Destroy On Load List")]

    [Keywords("Remove", "Delete", "Flush", "Destroy", "List")]
    [Image(typeof(IconCubeOutline), ColorTheme.Type.Red, typeof(OverlayMinus))]
    
    [Serializable]
	public class InstructionGameObjectDestroyList : Instruction
    {
  
	    public override string Title => "Dont Destroy On Load from List";

	    [System.Serializable]
	    public class TargetObjects
	    {
		    public GameObject targetObject;
	    }
	    [SerializeField] public List<TargetObjects> ListOfObjects = new List<TargetObjects>();
 
 

        protected override Task Run(Args args)
        {
	          for (int i = 0; i < ListOfObjects.Count; i++)
	        {
		          GameObject targetGO = ListOfObjects[i].targetObject;
		          if (targetGO != null)
		        {
			          GameObject.DontDestroyOnLoad(targetGO);
		        }
		       
	        }
	        	    	
	        return DefaultResult;
        }
        


    }
}