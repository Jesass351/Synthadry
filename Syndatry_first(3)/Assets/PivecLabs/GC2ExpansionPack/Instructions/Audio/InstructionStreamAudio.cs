using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.Networking;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Stream Audio from Web")]
[Description("Stream Audio from a URL")]
[Category("Audio/Stream Audio from Web")]

[Parameter("audioUrl", "The fully qualified URL of where the Audio is hosted")]
[Parameter("audiotype", "The type of Audio file")]

	[Keywords("Audio", "Music", "Ambience", "Background", "Stream", "URL", "Web")]
	[Image(typeof(IconHeadset), ColorTheme.Type.Yellow)]


	[Serializable]

	public class InstructionStreamAudio : Instruction
{


		[SerializeField] private PropertyGetString audioUrl;

		//	public StringProperty url = new StringProperty();
		private string streamingURL;

		public enum AUDIOTYPE
		{
			MP3,
			OGG,
			AIFF,
			WAV,
			XMA

		}

		[SerializeField] public AUDIOTYPE audiotype = AUDIOTYPE.OGG;
		private AudioType audioTYPE;
		private AudioClip clip;
		[SerializeField] private AudioConfigAmbient m_Config = new AudioConfigAmbient();


		public override string Title => "Stream Audio from Web";


		protected override async Task Run(Args args)
		{
			switch (this.audiotype)
			{
				case AUDIOTYPE.MP3:
					audioTYPE = AudioType.MPEG;
					break;
				case AUDIOTYPE.OGG:
					audioTYPE = AudioType.OGGVORBIS;
					break;
				case AUDIOTYPE.AIFF:
					audioTYPE = AudioType.AIFF;
					break;
				case AUDIOTYPE.WAV:
					audioTYPE = AudioType.WAV;
					break;
				case AUDIOTYPE.XMA:
					audioTYPE = AudioType.XMA;
					break;
			}
		
			streamingURL = this.audioUrl.Get(args);

			using (var uwr = UnityWebRequestMultimedia.GetAudioClip(streamingURL, audioTYPE))
			{
				UnityWebRequestAsyncOperation op = uwr.SendWebRequest();
				await this.Until(() => op.isDone);

				if (uwr.result == UnityWebRequest.Result.ConnectionError)
				{
					Debug.LogError(uwr.error);
					return;
				}

				clip = DownloadHandlerAudioClip.GetContent(uwr);

			}

			if (!AudioManager.Instance.Ambient.IsPlaying(this.clip))
			{
				_ = AudioManager.Instance.Ambient.Play(
					this.clip,
					this.m_Config,
					args
				);
			}

		
		}
		
	}
}