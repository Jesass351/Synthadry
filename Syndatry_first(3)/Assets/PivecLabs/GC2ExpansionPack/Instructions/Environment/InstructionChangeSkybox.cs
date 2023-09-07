using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Change Skybox")]
[Description("Changes a Non_Procedural Skybox")]
[Category("Environment/Change Skybox")]

[Parameter("Skybox", "Non-Procedural Skybox Reference")]

[Keywords("Skybox", "Lighting", "Environment")]
	[Image(typeof(IconSphereSolid), ColorTheme.Type.Blue)]

	[Serializable]
public class InstructionChangeSkybox : Instruction
{
	public override string Title => "Change Skybox";


	[SerializeField] public Material newSkyBox;

	protected override Task Run(Args args)
	{
			RenderSettings.skybox = newSkyBox;

			return DefaultResult;
	}
}
}