using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using PivecLabs.MinMaxSliderInt;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Execute Random Action from List with Fuzzy Logic")]
[Description("Executes a Random Action from a List using Fuzzy Logic")]
[Category("Random/Execute Random Action from List using Fuzzy Logic")]


[Keywords("Execute", "Call", "Instruction", "Random", "Action", "Fuzzy")]
[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]
[AddComponentMenu("")]
[Serializable]
	public class InstructionRandomActionFromListFuzzy : Instruction
	{
	public override string Title => string.Format(
		"Execute Random Action from List using Fuzzy Logic");
	
	[System.Serializable]
		public class ActionsObject
		{
			public Actions m_Action;
			[MinMaxInt(0, 100)]
			public MinMaxint FuzzySetting;
			[HideInInspector]
			public int Probability = 1;
		}

		[SerializeField] private List<ActionsObject> ListOfActions = new List<ActionsObject>();
		[SerializeField] private bool m_WaitToFinish = true;


	protected override async Task Run(Args args)
	{
		int rand = RandomProbability();
		

		Actions actions = this.ListOfActions[rand].m_Action;
		Debug.Log(actions.name);
		Debug.Log(rand);
		if (actions == null) return;

		if (this.m_WaitToFinish) await actions.Run(args);
		else _ = actions.Run(args);

         
	}
	
	public int RandomProbability()
		{
	
			if (ListOfActions.Capacity > 0)
			{
				for (int i = 0; i < ListOfActions.Capacity; i++)
				{
					if(ListOfActions[i].Probability==0) ListOfActions[i].Probability=1;
					
				}

			
			int weightTotal = 0;
			int result = 0, total = 0;

			for (int i = 0; i < ListOfActions.Capacity; i++)
			{
				int level = (ListOfActions[i].FuzzySetting.max - ListOfActions[i].FuzzySetting.min);
				
				int times = (int) UnityEngine.Random.Range(1, level); 

				ListOfActions[i].Probability=times;
				
				weightTotal += ListOfActions[i].Probability;
			}

	
			int randVal = UnityEngine.Random.Range(1, weightTotal);

			for (result = 0; result < ListOfActions.Capacity; result++)
			{
				total += ListOfActions[result].Probability;
				if (total > randVal) break;
			}

			return result;

		}
		return 0;
	}

	}
}