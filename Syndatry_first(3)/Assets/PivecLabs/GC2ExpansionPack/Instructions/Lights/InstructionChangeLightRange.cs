using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Change Light Range")]
[Description("Changes a the Range of a Light")]
[Category("Lights/Change Light Range")]

[Parameter("New Range", "New Range Setting for Light")]
[Parameter("Duration", "Time to change to New Range")]

    [Keywords("Spotlight", "Point Light", "Lighting", "Environment")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]

public class InstructionChangeLightRange : Instruction
{
        [SerializeField] private PropertyGetGameObject m_Light;
        [SerializeField] [Range(0, 100)] private float newRange;

        [SerializeField] private Transition m_Transition = new Transition();

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Light Range {this.m_Light} {this.newRange}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
            GameObject gameObject = this.m_Light.Get(args);
            if (gameObject == null) return;

            Light light = gameObject.Get<Light>();
            if (light == null) return;

            float valueSource = light.range;
 
            ITweenInput tween = new TweenInput<float>(
                valueSource,
                newRange,
                this.m_Transition.Duration,
                (a, b, t) => light.range = Mathf.Lerp(a, b, t),
                Tween.GetHash(typeof(Light), "Range"),
                this.m_Transition.EasingType
            );

            Tween.To(gameObject, tween);
            if (this.m_Transition.WaitToComplete) await this.Until(() => tween.IsFinished);
        }
    }
}