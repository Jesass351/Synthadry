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
[Title("Pause Audio Source")]
[Description("Pause an Audio Source")]
[Category("Audio/Pause Audio Source")]

    [Parameter("audioSource", "The Game Object with an Audio Source attached")]
 
    [Keywords("Audio", "Music", "Ambience", "Background", "AudioSource")]
	[Image(typeof(IconMusicNote), ColorTheme.Type.Yellow)]


	[Serializable]

	public class InstructionPauseAudioSource : Instruction
{

        [SerializeField] private PropertyGetGameObject audioSource;
  
        private AudioSource source;
   
        public override string Title => "Pause Audio Source";


		protected override Task Run(Args args)
		{
            GameObject gameObject = this.audioSource.Get(args);
            if (gameObject != null)
            {
                source = gameObject.GetComponent<AudioSource>();
                if (source != null)
                {
                    source.Pause();
                }
            }

            return DefaultResult;
        }
		
	}
}