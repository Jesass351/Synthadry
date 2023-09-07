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
    [Title("Remove Video from Object")]
    [Description("Remove Video from Object Material")]
    [Category("Video/Remove Video from Object")]

    [Parameter("targetObject", "The Game Object with a Video added")]
 
    [Keywords("Audio", "Video", "RenderSurface")]
    [Image(typeof(IconShotFixed), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionRemoveVideo : Instruction
    {


   
        [SerializeField] private PropertyGetGameObject targetObject;
   

        public override string Title => "Remove Video from Object";


		protected override Task Run(Args args)
		{
            GameObject target = this.targetObject.Get(args);
            if (target != null)
            {
   
                var vp = target.GetComponent<UnityEngine.Video.VideoPlayer>();
                var audioSource = target.GetComponent<AudioSource>();

                UnityEngine.Object.Destroy(vp);
                UnityEngine.Object.Destroy(audioSource);

            }
            return DefaultResult;
        }
     

            
   
		
	}
}