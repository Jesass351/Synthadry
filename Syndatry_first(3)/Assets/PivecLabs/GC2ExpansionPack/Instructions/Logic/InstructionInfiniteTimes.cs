using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using PivecLabs.MinMaxSliderInt;

namespace PivecLabs.GameCreator.VisualScripting
{

	[Version(1, 0, 1)]
    
	[Title("Execute Action Infinite Times")]
	[Description("Execute an Action a Infinite amount of times")]

	[Category("Logic/Execute Action Infinite Times")]

	[Parameter(
	"Actions",
	"The Actions object that is executed"
	)]

    
	[Keywords("Execute", "Call", "Instruction", "Infinite", "Repeat")]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue, typeof(OverlayDot))]

	[Serializable]
	public class InstructionInfiniteTimes : Instruction
	{
		[SerializeField] private PropertyGetGameObject m_Actions = GetGameObjectActions.Create();
		[SerializeField] private float Duration = 1f;
		[SerializeField] public bool orInfiniteTime;
		public override string Title => "Execute Action Infinite Times";
    
		protected override async Task Run(Args args)
		{
			Actions actions = this.m_Actions.Get<Actions>(args);
        
			if (actions == null) return;

			while ((Duration > 0) && (Application.isPlaying))
			{
				await actions.Run(args);
				if (orInfiniteTime == false)
					Duration--;

			}
		}
	}
}