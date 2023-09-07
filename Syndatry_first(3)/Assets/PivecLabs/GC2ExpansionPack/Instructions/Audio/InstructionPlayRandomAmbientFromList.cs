using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Play Random Music from List")]
[Description("Plays a Random Ambient Music from a List")]
[Category("Audio/Play Random Music from List")]


	[Parameter("Audio Clip", "The Audio Clip to be played")]
	[Parameter("Transition In", "Time it takes for the sound to fade in")]
	[Parameter("Spatial Blending", "Whether the sound is placed in a 3D space or not")]
	[Parameter("Target", "A Game Object reference that the sound follows as the source")]

	[Keywords("Audio", "Sounds", "Ambience", "Random", "Background")]
	[Image(typeof(IconHeadset), ColorTheme.Type.Yellow)]
	[Serializable]
	public class InstructionPlayRandomAmbientFromList : Instruction
	{
	public override string Title => string.Format(
	"Play Random Music from List");
	
	[System.Serializable]
		public class musicObject
		{
		public AudioClip ambientMusic;
		[Range(1,100)] public int Probability = 100;
		}

		[SerializeField] private List<musicObject> ListOfSounds = new List<musicObject>(10);
		[SerializeField] private bool m_WaitToFinish = true;
		[SerializeField] private AudioConfigAmbient audioConfig = new AudioConfigAmbient();

		private AudioClip m_AudioClip = null;


		protected override async Task Run(Args args)
	{
		int rand = RandomProbability();
			new AudioConfigAmbient();
			m_AudioClip = this.ListOfSounds[rand].ambientMusic;
			if (this.m_WaitToFinish)
			{
				await AudioManager.Instance.Ambient.Play(
					this.m_AudioClip,
					audioConfig,
					args
				);
			}
			else
			{
				_ = AudioManager.Instance.Ambient.Play(
					this.m_AudioClip,
					audioConfig,
					args
				);
			}

		}
	

	public int RandomProbability()
	{

		int weightTotal = 0;
		if (ListOfSounds.Capacity > 0)
		{
			for (int i = 0; i < ListOfSounds.Capacity; i++)
			{
				if(ListOfSounds[i].Probability==0) ListOfSounds[i].Probability=1;
				weightTotal += ListOfSounds[i].Probability;
			}

			int result = 0, total = 0;
			int randVal = UnityEngine.Random.Range(0, weightTotal);

			for (result = 0; result < ListOfSounds.Capacity; result++)
			{
				total += ListOfSounds[result].Probability;
				if (total > randVal) break;
			}

			return result;

		}
		return 0;
	}


	}
}