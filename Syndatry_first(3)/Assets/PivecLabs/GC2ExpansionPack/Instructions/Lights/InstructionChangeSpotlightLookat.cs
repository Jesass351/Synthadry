using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Change Spotlight Lookat")]
[Description("Changes the Direction of a Spotlight")]
[Category("Lights/Change Spotlight Lookat")]

[Parameter("Look at", "Object for Spotlight to Look At")]

    [Keywords("Spotlight", "Lighting", "Environment")]
	[Image(typeof(IconLight), ColorTheme.Type.Yellow)]

public class InstructionChangeSpotlightLookat : Instruction
{
        [SerializeField] private PropertyGetGameObject m_Light;
        [SerializeField] private PropertyGetGameObject lookAt = GetGameObjectTransform.Create();
  
        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Change Spotlight {this.m_Light} to look at {this.lookAt}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override Task Run(Args args)
        {
            GameObject gameObject = this.m_Light.Get(args);
            if (gameObject == null) return DefaultResult;

            GameObject gameObjectT = this.lookAt.Get(args);
            if (gameObjectT == null) return DefaultResult;

            Light light = gameObject.Get<Light>();
            if (light == null) return DefaultResult;


            if (light.type == LightType.Spot)

            {

                light.transform.LookAt(gameObjectT.transform.position, Vector3.up);

           }

            return DefaultResult;
        }
    }
}