using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Change Skybox Exposure")]
    [Description("Changes a Skybox Exposure")]
    [Category("Environment/Change Skybox Exposure")]

    [Parameter("Skybox", "Procedural Skybox Reference")]

    [Keywords("Skybox", "Lighting", "Environment", "Exposure")]
    [Image(typeof(IconSphereSolid), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionChangeSkyboxExposure : Instruction
    {
        public override string Title => "Change Skybox Exposure";

        [SerializeField]
        [Range(0, 18)]
        public float exposureSetting;
 
        [SerializeField]
        [Range(0, 10)]
        public float changeSpeed;

        private float currentSetting;

        protected override async Task Run(Args args)
        {
            currentSetting = RenderSettings.skybox.GetFloat("_Exposure");
            await change();
        }

        private async Task change()
        {
            float timeElapsed = 0;

            while ((timeElapsed < changeSpeed) && Application.isPlaying)
            {
                float valueToLerp = Mathf.Lerp(currentSetting, exposureSetting, timeElapsed / changeSpeed);
                timeElapsed += UnityEngine.Time.deltaTime;
                RenderSettings.skybox.SetFloat("_Exposure", valueToLerp);
                Debug.Log(timeElapsed);

	            await this.NextFrame();
     
            }

	        await this.NextFrame();


        }
    }
}