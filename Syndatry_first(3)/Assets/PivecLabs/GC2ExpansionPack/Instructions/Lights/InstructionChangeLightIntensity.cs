using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Change Light Intensity")]
[Description("Changes a the Intensity of a Light")]
[Category("Lights/Change Light Intensity")]

[Parameter("New Range", "New Intensity Setting for Light")]
[Parameter("Duration", "Time to change to New Intensity")]

    [Keywords("Spotlight", "Point Light", "Lighting", "Environment", "Intensity")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]

public class InstructionChangeLightIntensity : Instruction
{
        [SerializeField] private PropertyGetGameObject m_Light;
        [SerializeField] [Range(0, 100)] private float newIntensity;

        [SerializeField] private Transition m_Transition = new Transition();

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Light Intensity {this.m_Light} {this.newIntensity}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
            GameObject gameObject = this.m_Light.Get(args);
            if (gameObject == null) return;

            Light light = gameObject.Get<Light>();
            if (light == null) return;
  
            float valueSource = light.intensity;
 
            ITweenInput tween = new TweenInput<float>(
                valueSource,
                newIntensity,
                this.m_Transition.Duration,
                (a, b, t) => light.intensity = Mathf.Lerp(a, b, t),
                Tween.GetHash(typeof(Light), "intensity"),
                this.m_Transition.EasingType
            );

            Tween.To(gameObject, tween);
            if (this.m_Transition.WaitToComplete) await this.Until(() => tween.IsFinished);
        }
    }
}