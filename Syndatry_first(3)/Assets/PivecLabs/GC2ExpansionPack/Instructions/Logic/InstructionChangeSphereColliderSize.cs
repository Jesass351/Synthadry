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
	[Title("Change Sphere Collider Size")]
	[Description("Change the Size of a Sphere Collider")]
	[Category("Logic/Change Sphere Collider Size")]

	[Parameter("colliderObject", "The Sphere Collider to be changed")]

	[Keywords("Collider", "Size", "Change", "Sphere")]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue, typeof(OverlayDot))]


	[Serializable]

	public class InstructionChangeSphereColliderSize : Instruction
	{

		[SerializeField] private PropertyGetGameObject m_Collider;

		[SerializeField]
		[Range(0, 100)]
		public float newRadius;

		[SerializeField] private Transition m_Transition = new Transition();



		public override string Title => "Change Sphere Collider Size";


		protected override async Task Run(Args args)
		{
			GameObject gameObject = this.m_Collider.Get(args);
			if (gameObject == null) return;

			SphereCollider collider = gameObject.GetComponent<SphereCollider>();

			float oldSize = collider.radius;
			float initTime = UnityEngine.Time.time;


				ITweenInput tween = new TweenInput<float>(
					oldSize,
					newRadius,
					this.m_Transition.Duration,
					 (a, b, t) => collider.radius = Mathf.Lerp(a, b, t),
					Tween.GetHash(typeof(Collider), "radius"),
					this.m_Transition.EasingType
				);

				Tween.To(gameObject, tween);
				if (this.m_Transition.WaitToComplete) await this.Until(() => tween.IsFinished);
			}
		}
	
}
			
		