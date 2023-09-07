using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Attract RigidBody Object")]
    [Description("Attract Object with RigidBody")]
    [Category("Physics 3D/Attract RigidBody Object")]

    [Parameter("targetObject", "The Game Object with a Video added")]
 
    [Keywords("Physics", "Attract", "Rigidbody")]
    [Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayArrowRight))]



    [Serializable]

    public class InstructionAttractObjectbyRigidBody : Instruction
    {

	    [SerializeField] private GameObject targetObject;
        [SerializeField] private GameObject rigidbodyObject;

        [SerializeField] private PropertyGetDecimal m_Force = new PropertyGetDecimal(10f);
        [SerializeField] private ForceMode m_ForceMode = ForceMode.Impulse;
		private float intensity;
		private Vector3 newForce;



		public override string Title => "Attract Object with RigidBody";


		protected override Task Run(Args args)
	    {
			
			float forceAmount = (float)this.m_Force.Get(args);

			Rigidbody targetRB = rigidbodyObject.GetComponent<Rigidbody>();
			if (targetRB != null)
			{
				intensity = Vector3.Distance(targetObject.transform.position, rigidbodyObject.transform.position);

				newForce = ((targetObject.transform.position - rigidbodyObject.transform.position) * intensity * forceAmount * UnityEngine.Time.deltaTime);

				targetRB.AddForce(newForce, this.m_ForceMode);

			}

			return DefaultResult;
        }
     

            
   
		
	}
}