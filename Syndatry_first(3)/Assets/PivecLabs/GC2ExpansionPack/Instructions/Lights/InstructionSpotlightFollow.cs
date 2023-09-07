using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using PivecLabs.MinMaxSliderInt;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("SpotLight Follow Object")]
[Description("Have a SpotLight Follow an Object")]
[Category("Lights/SpotLight Follow Object")]

[Parameter("New Range", "New Intensity Setting for Light")]
[Parameter("Duration", "Time to change to New Intensity")]

    [Keywords("Spotlight", "Point Light", "Lighting", "Flicker", "Intensity")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]

public class InstructionSpotlightFollow : Instruction
{
        [SerializeField] private PropertyGetGameObject m_Light;
		[SerializeField] private PropertyGetGameObject lookAt = GetGameObjectTransform.Create();

		[SerializeField] private float Duration = 1f;
		[SerializeField] public bool orInfiniteTime;

		// PROPERTIES: ----------------------------------------------------------------------------

		public override string Title => $"SpotLight Follow Object {this.m_Light}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
			GameObject gameObject = this.m_Light.Get(args);
			GameObject gameObjectT = this.lookAt.Get(args);
			Light light = gameObject.Get<Light>();
			if (light.type == LightType.Spot)
            {
				while ((Duration > 0) && (Application.isPlaying))
				{
					light.transform.LookAt(gameObjectT.transform.position, Vector3.up);

					if (orInfiniteTime == false)
						Duration--;
					await this.NextFrame();
				}
				
				await this.NextFrame();
			}
				
		}
    }
}