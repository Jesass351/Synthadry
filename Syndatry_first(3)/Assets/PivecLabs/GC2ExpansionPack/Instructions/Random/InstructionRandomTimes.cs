using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using PivecLabs.MinMaxSliderInt;

namespace PivecLabs.GameCreator.VisualScripting
{

	[Version(1, 0, 1)]
    
	[Title("Execute Action Random Times")]
	[Description("Execute an Action a Random amount of times")]

	[Category("Random/Execute Action Random Times")]

	[Parameter(
	"Actions",
	"The Actions object that is executed"
	)]
	[Parameter("MaxTimes", "The Maximum value that is set")]


    
	[Keywords("Execute", "Call", "Instruction", "Random", "Repeat")]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue, typeof(OverlayDot))]

	[Serializable]
	public class InstructionRandomTimes : Instruction
	{
		[SerializeField] private PropertyGetGameObject m_Actions = GetGameObjectActions.Create();
		[SerializeField] [MinMaxInt(0, 60)]
		public MinMaxint MinMaxTimes;
		public override string Title => "Execute Action Random Times";
    
		protected override async Task Run(Args args)
		{
			Actions actions = this.m_Actions.Get<Actions>(args);
			int times = (int) UnityEngine.Random.Range(MinMaxTimes.min, MinMaxTimes.max); 
        
			if (actions == null) return;

			for (int i = 0; i < times; ++i)
			{
				await actions.Run(args);
			}
		}
	}
}