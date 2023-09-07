using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Change Procedural Skybox")]
    [Description("Changes a Procedural Skybox")]
    [Category("Environment/Change Procedural Skybox")]

    [Parameter("Skybox", "Procedural Skybox Reference")]

    [Keywords("Skybox", "Lighting", "Environment", "Procedural")]
    [Image(typeof(IconSphereSolid), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionChangeProceduralSkybox : Instruction
    {
        public override string Title => "Change Procedural Skybox";

        [SerializeField] private Material newSkyBox;

         [SerializeField] [Range(20f, 1f)] private float changeSpeed = 1.0f;

        protected override async Task Run(Args args)
        {
            Material defaultSky = RenderSettings.skybox;
            Material tempSky = new Material(Shader.Find("Skybox/Procedural"));
            RenderSettings.skybox = tempSky;
            RenderSettings.skybox.Lerp(RenderSettings.skybox, defaultSky, 1);

            await change();
        }

        private async Task change()
        {
  
            float initTime = UnityEngine.Time.unscaledTime;

   
            while ((UnityEngine.Time.unscaledTime - initTime < changeSpeed) && Application.isPlaying)
            {
                float t1 = ((UnityEngine.Time.unscaledTime - initTime) / changeSpeed);
                RenderSettings.skybox.Lerp(RenderSettings.skybox, newSkyBox, t1);

	            await this.NextFrame();
     
            }

	        await this.NextFrame();


        }
    }
}