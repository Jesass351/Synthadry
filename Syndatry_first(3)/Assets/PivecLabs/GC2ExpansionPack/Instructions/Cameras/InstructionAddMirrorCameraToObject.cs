using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Add Mirror Camera to Object")]
    [Description("Add a Mirror Camera to Object Material")]
    [Category("Cameras/Add Mirror Camera to Object")]

    [Parameter("targetObject", "The Game Object to place the Mirror on")]
 
    [Keywords("Audio", "Video", "RenderSurface","Camera", "Mirror")]
    [Image(typeof(IconShotFixed), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionAddMirrorCameraToObject : Instruction
    {

  
   
        [SerializeField] private PropertyGetGameObject ObjectForMirror;
 
        private Camera targetCamera;
        private RenderTexture targetRenderTexture;
        private Quaternion currentRotation;
        [SerializeField] private Vector3 Direction = new Vector3(-90.0f, 0f, 0f);
        [SerializeField] private float FOV = (60.0f);


        public override string Title => "Add Mirror Camera to Object";


		protected override Task Run(Args args)
		{
             GameObject targetObject1 = this.ObjectForMirror.Get(args);
            if (targetObject1 != null)
            {

                targetRenderTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
                targetRenderTexture.Create();


                GameObject camera3d = new GameObject();
                targetCamera = camera3d.AddComponent<Camera>();
                targetCamera.transform.SetParent(targetObject1.transform);
                targetCamera.transform.localPosition = new Vector3(0, 0, 0);


                targetCamera.enabled = true;
                targetCamera.allowHDR = true;
                targetCamera.orthographic = false;
                targetCamera.fieldOfView = FOV;
                targetCamera.name = "MirrorCamera";

                targetCamera.clearFlags = CameraClearFlags.SolidColor;
                targetCamera.backgroundColor = Color.clear;

                targetCamera.targetTexture = targetRenderTexture;
                targetCamera.Render();


                Renderer render = targetObject1.GetComponent<Renderer>();
                if (render != null) render.material.mainTexture = targetRenderTexture;

                 currentRotation.eulerAngles = Direction;
                targetCamera.transform.localRotation = currentRotation;

            }
     

            return DefaultResult;
        }
		
	}
}