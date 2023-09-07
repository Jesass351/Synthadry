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
    [Title("Play Audio Source")]
    [Description("Play an Audio Source")]
    [Category("Audio/Play Audio Source")]

    [Parameter("audioSource", "The Game Object with an  Audio Source attached")]
    [Parameter("duration", "UI text to display the length of the Audio Clip")]

    [Keywords("Audio", "Music", "Ambience", "Background", "AudioSource")]
    [Image(typeof(IconMusicNote), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionPlayAudioSource : Instruction
    {

        [SerializeField] private PropertyGetGameObject audioSource;
        [SerializeField]
        [Range(0f, 1f)] public float volume = 1f;
        [SerializeField] public Text duration;

        private AudioSource source;


        public override string Title => "Play Audio Source";


		protected override Task Run(Args args)
		{
            GameObject gameObject = this.audioSource.Get(args);
            if (gameObject != null)
            {
                source = gameObject.GetComponent<AudioSource>();
                if (source != null)
                {
                    source.Play(0);
                    source.volume = this.volume;

                }
            }


            if (duration != null)
            {
                int min = Mathf.FloorToInt(source.clip.length / 60);
                int sec = Mathf.FloorToInt(source.clip.length % 60);
                duration.text = min + ":" + sec;
            }

            return DefaultResult;
        }
		
	}
}