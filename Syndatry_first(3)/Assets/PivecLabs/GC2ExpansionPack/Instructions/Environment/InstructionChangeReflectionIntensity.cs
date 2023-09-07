using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Change Reflection Intensity")]
[Description("Changes the Reflection Intensity")]
[Category("Environment/Change Reflection Intensity")]

[Parameter("Reflection Intensity", "Reflection Intensity Intensity")]

	[Keywords("Ambient", "Lighting", "Environment", "Reflection")]
	[Image(typeof(IconSphereSolid), ColorTheme.Type.Blue)]

	[Serializable]
	public class InstructionChangeReflectionIntensity : Instruction
{
	public override string Title => "Change Reflection Intensity";


		[SerializeField] public float ReflectionIntensity;
		protected override Task Run(Args args)
	{
			RenderSettings.reflectionIntensity = ReflectionIntensity;

			return DefaultResult;
	}
}
}