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
    [Title("Pause Video on Object")]
    [Description("Pause a Video on Object Material")]
    [Category("Video/Pause Video on Object")]

    [Parameter("targetObject", "The Game Object with a Video added")]
 
    [Keywords("Audio", "Video", "RenderSurface")]
    [Image(typeof(IconShotFixed), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionPauseVideo : Instruction
    {


   
        [SerializeField] private PropertyGetGameObject targetObject;
   

        public override string Title => "Pause Video on Object";


		protected override Task Run(Args args)
		{
            GameObject target = this.targetObject.Get(args);
            if (target != null)
            {
   
                var vp = target.GetComponent<UnityEngine.Video.VideoPlayer>();

                vp.Pause();

            }
            return DefaultResult;
        }
     

            
   
		
	}
}