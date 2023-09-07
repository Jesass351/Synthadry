using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Change Ambient Lighting")]
[Description("Changes Ambient Lighting")]
[Category("Environment/Change Ambient Lighting")]

[Parameter("Lighting Intensity", "Ambient Light Intensity")]
[Parameter("Lighting Color", "Ambient Light Color")]

	[Keywords("Ambient", "Lighting", "Environment")]
	[Image(typeof(IconSphereSolid), ColorTheme.Type.Blue)]

	[Serializable]
public class InstructionChangeAmbientLighting : Instruction
{
	public override string Title => "Change Ambient Lighting";


		[SerializeField] public float LightingIntensity;
		[SerializeField] public Color LightingColor;
		protected override Task Run(Args args)
	{
			RenderSettings.ambientIntensity = LightingIntensity;
			RenderSettings.ambientLight = LightingColor;

			return DefaultResult;
	}
}
}