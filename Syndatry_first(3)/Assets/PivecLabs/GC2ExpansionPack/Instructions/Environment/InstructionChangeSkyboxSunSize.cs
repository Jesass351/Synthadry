using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Change Skybox Sun Size")]
    [Description("Changes a Skybox Sun Size")]
    [Category("Environment/Change Skybox Sun Size")]

    [Parameter("Skybox", "Procedural Skybox Reference")]

    [Keywords("Skybox", "Lighting", "Environment", "Sun Size")]
    [Image(typeof(IconSphereSolid), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionChangeSkyboxSunSize : Instruction
    {
        public override string Title => "Change Skybox Sun Size";

        [SerializeField]
        [Range(0, 1)]
        public float sunSize;
 
        [SerializeField]
        [Range(0, 10)]
        public float changeSpeed;

        private float currentSetting;

        protected override async Task Run(Args args)
        {
            currentSetting = RenderSettings.skybox.GetFloat("_SunSize");
            await change();
        }

        private async Task change()
        {
            float timeElapsed = 0;

            while ((timeElapsed < changeSpeed) && Application.isPlaying)
            {
                float valueToLerp = Mathf.Lerp(currentSetting, sunSize, timeElapsed / changeSpeed);
                timeElapsed += UnityEngine.Time.deltaTime;
                RenderSettings.skybox.SetFloat("_SunSize", valueToLerp);
                Debug.Log(timeElapsed);

	            await this.NextFrame();
     
            }

	        await this.NextFrame();


        }
    }
}