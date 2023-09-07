using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using PivecLabs.MinMaxSliderFloat;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Flicker Light Intensity")]
[Description("Flicker a the Intensity of a Light")]
[Category("Lights/Flicker Light Intensity")]

[Parameter("New Range", "New Intensity Setting for Light")]
[Parameter("Duration", "Time to change to New Intensity")]

    [Keywords("Spotlight", "Point Light", "Lighting", "Flicker", "Intensity")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]

public class InstructionFlickerRenderer : Instruction
{
        [SerializeField] private PropertyGetGameObject m_Light;
 		[SerializeField]
 		[MinMaxFloat(0, 20)]
	public MinMaxfloat intensityRange;

		[SerializeField]
		[MinMaxFloat(0, 3)]
	public MinMaxfloat timeRange;

		[SerializeField] private float Duration = 1f;
		[SerializeField] public bool orInfiniteTime;

		// PROPERTIES: ----------------------------------------------------------------------------

		public override string Title => $"Flicker Light Intensity {this.m_Light}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
            GameObject gameObject = this.m_Light.Get(args);
            if (gameObject == null) return;

            Light light = gameObject.Get<Light>();
            if (light == null) return;

			while ((Duration > 0) && (Application.isPlaying))
			{
				light.intensity = (UnityEngine.Random.Range(intensityRange.min, intensityRange.max));
				await this.Time(UnityEngine.Random.Range(timeRange.min, timeRange.max));

				light.intensity = (UnityEngine.Random.Range(intensityRange.min, intensityRange.max));
				await this.Time(UnityEngine.Random.Range(timeRange.min, timeRange.max));

				if (orInfiniteTime == false)
				Duration--;
			}
			light.intensity = intensityRange.max;
	        await this.NextFrame();
		}
    }
}