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
    [Title("Add Video to Object")]
    [Description("Add a Video to Object Material")]
    [Category("Video/Add Video to Object")]

    [Parameter("targetObject", "The Game Object to place the Video on")]
 
    [Keywords("Audio", "Video", "RenderSurface")]
    [Image(typeof(IconShotFixed), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionAddVideo : Instruction
    {

        [SerializeField] public VIDEOORIGIN videoOrigin = VIDEOORIGIN.Local;
        [SerializeField] public UnityEngine.Video.VideoClip localVideo;

        [SerializeField] private PropertyGetString videoUrl;
        private string streamingURL;

        public enum VIDEOORIGIN
        {
            Local,
            URL
        }

   
        [SerializeField] private PropertyGetGameObject targetObject;
        [Space]
        [SerializeField] public bool playOnAwake;


        public override string Title => "Add Video to Object";


		protected override Task Run(Args args)
		{
            GameObject target = this.targetObject.Get(args);
             if (target != null)
            {


                var videoPlayer = target.AddComponent<UnityEngine.Video.VideoPlayer>();
                var audioSource = target.AddComponent<AudioSource>();

                videoPlayer.playOnAwake = playOnAwake;

                switch (this.videoOrigin)
                {
                    case VIDEOORIGIN.Local:
                        videoPlayer.clip = localVideo;
                        break;
                    case VIDEOORIGIN.URL:
                        videoPlayer.url = this.videoUrl.Get(args);
                        break;
                }


                videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
                videoPlayer.playOnAwake = false;

                videoPlayer.targetMaterialRenderer = target.GetComponent<Renderer>();
                videoPlayer.targetMaterialProperty = "_MainTex";
                videoPlayer.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.AudioSource;
                videoPlayer.SetTargetAudioSource(0, audioSource);

            }
     

            return DefaultResult;
        }
		
	}
}