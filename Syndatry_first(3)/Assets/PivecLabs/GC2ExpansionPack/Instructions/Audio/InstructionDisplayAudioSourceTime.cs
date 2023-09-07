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
[Title("Display Audio Source Time")]
[Description("Display Audio Source Time")]
[Category("Audio/Display Audio Source Time")]

    [Parameter("audioSource", "The Game Object with an Audio Source attached")]
 
    [Keywords("Audio", "Music", "Ambience", "Background", "AudioSource")]
	[Image(typeof(IconMusicNote), ColorTheme.Type.Yellow)]


	[Serializable]

	public class InstructionDisplayAudioSourceTime : Instruction
{

        [SerializeField] private PropertyGetGameObject audioSource;
        [SerializeField] public Text currentTime;

        private AudioSource source;
   
        public override string Title => "Display Audio Source Time";


		protected override Task Run(Args args)
		{
            GameObject gameObject = this.audioSource.Get(args);
            if (gameObject != null)
            {
                source = gameObject.GetComponent<AudioSource>();
                   if (currentTime != null)
                    {
                        int min = Mathf.FloorToInt(source.time / 60);
                        int sec = Mathf.FloorToInt(source.time % 60);
                        currentTime.text = min + ":" + sec;
                    }
               
            }

            return DefaultResult;
        }
		
	}
}