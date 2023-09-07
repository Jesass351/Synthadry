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
using PivecLabs.CustomTagSelector;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Repel RigidBody Object bt Tag")]
    [Description("Repel Object with RigidBody by Tag")]
    [Category("Physics 3D/Repel RigidBody Object by Tag")]

    [Parameter("targetObject", "The Game Object Targetted")]
	[Parameter("rigidbodyObject", "The Game Object with Rigidbody")]

	[Keywords("Physics", "Repel", "Rigidbody", "Tag")]
    [Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayArrowRight))]



    [Serializable]

    public class InstructionRepelObjectbyRigidBodybyTag : Instruction
    {

	    [SerializeField] private GameObject targetObject;
		[SerializeField] [TagSelector] public string tagStr = "";

		[SerializeField] private PropertyGetDecimal m_Force = new PropertyGetDecimal(10f);
        [SerializeField] private ForceMode m_ForceMode = ForceMode.Impulse;
		private float intensity;
		private Vector3 newForce;



		public override string Title => "Repel Object with RigidBody by Tag";


		protected override Task Run(Args args)
	    {
			
			float forceAmount = (float)this.m_Force.Get(args);

			GameObject[] objects = GameObject.FindGameObjectsWithTag(tagStr);

			if (objects.Length < 1)
			{
				return DefaultResult;
			}
			foreach (GameObject go in objects)

			{
				Rigidbody targetRB = go.GetComponent<Rigidbody>();

				intensity = Vector3.Distance(targetObject.transform.position, go.transform.position);

				newForce = ((go.transform.position - targetObject.transform.position) * intensity * forceAmount * UnityEngine.Time.deltaTime);

				targetRB.AddForce(newForce, this.m_ForceMode);


			}

			return DefaultResult;
        }
     

            
   
		
	}
}