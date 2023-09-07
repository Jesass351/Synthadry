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
using PivecLabs.MinMaxSliderFloat;


namespace PivecLabs.GameCreator.VisualScripting
{

	[Version(1, 0, 1)]
	[Title("Random Box Collider Size")]
	[Description("Random Size of a Box Collider")]
	[Category("Logic/Random Box Collider Size")]

	[Parameter("colliderObject", "The Collider to be changed")]

	[Keywords("Collider", "Size", "Change", "Random", "Sphere")]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue, typeof(OverlayDot))]


	[Serializable]

	public class InstructionRandomBoxColliderSize : Instruction
	{

		[SerializeField] private PropertyGetGameObject m_Collider;

		[SerializeField]
		[MinMaxFloat(0, 100)]
		public MinMaxfloat RandomSize;


		[SerializeField] private Transition m_Transition = new Transition();



		public override string Title => "Random Box Collider Size";


		protected override async Task Run(Args args)
		{
			GameObject gameObject = this.m_Collider.Get(args);
			if (gameObject == null) return;

			BoxCollider collider = gameObject.GetComponent<BoxCollider>();

			float floatSize = UnityEngine.Random.Range(RandomSize.min, RandomSize.max);

			Vector3 oldSize = collider.size;
			Vector3 newSize = new Vector3(floatSize,floatSize,floatSize);
			float initTime = UnityEngine.Time.time;


			ITweenInput tween = new TweenInput<Vector3>(
				oldSize,
				newSize,
				this.m_Transition.Duration,
				(a, b, t) => collider.size = Vector3.LerpUnclamped(a, b, t),
				Tween.GetHash(typeof(Collider), "size"),
				this.m_Transition.EasingType
			);

				Tween.To(gameObject, tween);
				if (this.m_Transition.WaitToComplete) await this.Until(() => tween.IsFinished);
			}
		}
	
}
			
		