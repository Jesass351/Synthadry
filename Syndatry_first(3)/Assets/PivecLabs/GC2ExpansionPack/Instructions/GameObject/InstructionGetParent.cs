using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Get Parent of Object")]
    [Description("Get Parent of Object and Store")]
    [Category("Game Objects/Get Parent of Object")]

    [Keywords("Object", "Variable", "Parent")]
    [Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]


    [Serializable]

	public class InstructionGetParent : Instruction
    {


   
	    [SerializeField]private PropertyGetGameObject m_targetObject;
	    [SerializeField]private PropertySetGameObject m_variable = new PropertySetGameObject();
	    private GameObject outputGameObject;
	    private Transform parenttrans;


        public override string Title => "Get Parent of Object";


		protected override Task Run(Args args)
		{
   
			GameObject target = this.m_targetObject.Get(args);

			if (target != null)
			{
				parenttrans = target.transform.parent;
				outputGameObject = parenttrans.gameObject;
			}
            
			this.m_variable.Set(outputGameObject, target);
           
            return DefaultResult;
        }
     

            
   
		
	}
}