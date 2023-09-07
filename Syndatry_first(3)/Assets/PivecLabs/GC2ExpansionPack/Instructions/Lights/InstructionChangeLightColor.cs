using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Change Light Color")]
[Description("Changes a the Color of a Light")]
[Category("Lights/Change Light Color")]

[Parameter("New Range", "New Color Setting for Light")]

    [Keywords("Spotlight", "Point Light", "Lighting", "Environment", "Color")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]

public class InstructionChangeLightColor : Instruction
{
        [SerializeField] private PropertyGetGameObject m_Light;
        [SerializeField] public Color newColor;
        [SerializeField] public bool orRandomColor = false;
        [SerializeField] private Transition m_Transition = new Transition();

        private Color colorValue;

        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Light Color {this.m_Light} {this.newColor}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override async Task Run(Args args)
        {
            GameObject gameObject = this.m_Light.Get(args);
            if (gameObject == null) return;

            Light light = gameObject.Get<Light>();
            if (light == null) return;

            Color valueSource = light.color;
            if (orRandomColor == true)
            {
                colorValue = RandomColor();
            }
            else
            {
                colorValue = this.newColor;
            }
   
            ITweenInput tween = new TweenInput<Color>(
                valueSource,
                colorValue,
                this.m_Transition.Duration,
                (a, b, t) => light.color = Color.Lerp(a, b, t),
                Tween.GetHash(typeof(Light), "color"),
                this.m_Transition.EasingType
            );

            Tween.To(gameObject, tween);
            if (this.m_Transition.WaitToComplete) await this.Until(() => tween.IsFinished);
        }
        public static Color RandomColor()
        {
            var hue = UnityEngine.Random.Range(0f, 1f);
            return Color.HSVToRGB(hue, 1f, 1f);
        }
    }
}