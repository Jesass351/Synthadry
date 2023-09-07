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

    [Version(0, 1, 1)]

    [Title("Play Random Sound Effect from Folder")]
    [Description("Plays a Random Audio Clip sound effect from a Folder")]

    [Category("Audio/Play Random Sound Effect from Folder")]

    [Parameter("Audio Clip", "The Audio Clip to be played")]
    [Parameter("Wait To Complete", "Check if you want to wait until the sound finishes")]
    [Parameter("Pitch", "A random pitch value ranging between two values")]
    [Parameter("Transition In", "Time it takes for the sound to fade in")]
    [Parameter("Spatial Blending", "Whether the sound is placed in a 3D space or not")]
    [Parameter("Target", "A Game Object reference that the sound follows as its source")]

    [Keywords("Audio", "Sounds", "Random")]
    [Image(typeof(IconMusicNote), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCommonAudioSFXPlay : Instruction
    {
        [SerializeField] private string FolderName = "Sounds";

        private AudioClip m_AudioClip = null;
        [SerializeField] private bool m_WaitToComplete = false;

        [SerializeField] private AudioConfigSoundEffect m_Config = new AudioConfigSoundEffect();
        private UnityEngine.Object[] soundClips;

        public override string Title => string.Format(
            "Play Random Sound Effect from Folder"
        );

        protected override async Task Run(Args args)
        {

            if (soundClips == null)
                soundClips = Resources.LoadAll(FolderName, typeof(AudioClip));

            m_AudioClip = (AudioClip)soundClips[UnityEngine.Random.Range(0, soundClips.Length)];

            if (this.m_WaitToComplete)
            {
                await AudioManager.Instance.SoundEffect.Play(
                    this.m_AudioClip,
                    this.m_Config,
                    args
                );
            }
            else
            {
                _ = AudioManager.Instance.SoundEffect.Play(
                    this.m_AudioClip,
                    this.m_Config,
                    args
                );
            }
        }
    }
}