using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using PivecLabs.MinMaxSliderInt;


namespace PivecLabs.GameCreator.VisualScripting
{

	[Version(1, 0, 1)]
    
	[Title("Random Wait Time in Minutes")]
	[Description("Waits Random Amount of Minutes")]

	[Category("Random/Random Wait Time in Minutes")]

	[Parameter("MinMaxWait", "The Minimum/Maximum value that is set")]


    
	[Keywords("Wait", "Random")]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue, typeof(OverlayDot))]

	[Serializable]
	public class InstructionRandomWaitMinutes : Instruction
	{
		[SerializeField] [MinMaxInt(0, 60)]
		public MinMaxint MinMaxWait;

		public override string Title => "Random Wait Time in Minutes";
    
		protected override async Task Run(Args args)
		{

			float value = UnityEngine.Random.Range(MinMaxWait.min, MinMaxWait.max); 

			await this.Time(value*60);
		}
	}
}