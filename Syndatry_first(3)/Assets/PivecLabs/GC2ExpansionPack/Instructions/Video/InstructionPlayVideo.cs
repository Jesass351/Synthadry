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
    [Title("Play Video on Object")]
    [Description("Play a Video on Object Material")]
    [Category("Video/Play Video on Object")]

    [Parameter("targetObject", "The Game Object with a Video added")]
 
    [Keywords("Audio", "Video", "RenderSurface")]
    [Image(typeof(IconShotFixed), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionPlayVideo : Instruction
    {


   
        [SerializeField] private PropertyGetGameObject targetObject;
        [SerializeField] private bool startOnFrame = true;
        [SerializeField] private PropertyGetDecimal startFrame;
        [Space]
        [Space]
        [SerializeField] private bool loopVideo = false;

        [SerializeField] [Range(0.0f, 10.0f)] private float playbackSpeed = 1.0f;
        [SerializeField] [Range(0.0f, 1.0f)] private float audioVolume = 1.0f;
        [SerializeField] [Range(0.0f, 1.0f)] private float spatialBlend = 0.0f;


        public override string Title => "Play Video on Object";


		protected override Task Run(Args args)
		{
            GameObject target = this.targetObject.Get(args);
            if (target != null)
            {
                var audioSource = target.GetComponent<AudioSource>();

                var vp = target.GetComponent<UnityEngine.Video.VideoPlayer>();
                if (loopVideo)
                {
                    vp.isLooping = true;
                }

                audioSource.spatialBlend = spatialBlend;
                audioSource.volume = audioVolume;
                vp.waitForFirstFrame = startOnFrame;
                vp.playbackSpeed = playbackSpeed;
                if (startOnFrame)
                {
                  long value = (long)this.startFrame.Get(args);
                    vp.frame = value;

                }

                vp.Play();

            }
            return DefaultResult;
        }
     

            
   
		
	}
}