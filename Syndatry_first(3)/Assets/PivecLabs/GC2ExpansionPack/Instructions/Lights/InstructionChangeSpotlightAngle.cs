using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Change Spotlight Angle")]
[Description("Changes the Angle of a Spotlight")]
[Category("Lights/Change Spotlight Angle")]

[Parameter("NewAngle", "New Angle for Spotlight")]
[Parameter("Duration", "Time to change to New Angle")]

    [Keywords("Spotlight", "Lighting", "Environment")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]

public class InstructionChangeSpotlightAngle : Instruction
{
        [SerializeField] private PropertyGetGameObject m_Light;
        [SerializeField] [Range(0, 100)] private float newAngle;

        [SerializeField] private Transition m_Transition = new Transition();

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Spotlight Angle {this.m_Light} {this.newAngle}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
            GameObject gameObject = this.m_Light.Get(args);
            if (gameObject == null) return;

            Light light = gameObject.Get<Light>();
            if (light == null) return;

            float valueSource = light.spotAngle;
 
            ITweenInput tween = new TweenInput<float>(
                valueSource,
                newAngle,
                this.m_Transition.Duration,
                (a, b, t) => light.spotAngle = Mathf.Lerp(a, b, t),
                Tween.GetHash(typeof(Light), "spotAngle"),
                this.m_Transition.EasingType
            );

            Tween.To(gameObject, tween);
            if (this.m_Transition.WaitToComplete) await this.Until(() => tween.IsFinished);
        }
    }
}