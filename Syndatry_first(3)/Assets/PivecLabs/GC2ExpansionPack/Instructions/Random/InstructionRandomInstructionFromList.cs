using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Execute Random Instruction from List")]
[Description("Executes a Random Instruction from a List")]
[Category("Random/Execute Random Instruction from List")]


[Keywords("Execute", "Call", "Instruction", "Random")]
[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]
[AddComponentMenu("")]
[Serializable]
	public class InstructionRandomInstructionFromList : Instruction
	{
	public override string Title => string.Format(
	"Execute Random Instruction from List");
	
	[System.Serializable]
		public class ActionsObject
		{
		public Actions m_Action;
		[Range(1,100)] public int Probability = 100;
		}

		[SerializeField] private List<ActionsObject> ListOfActions = new List<ActionsObject>();
		[SerializeField] private bool m_WaitToFinish = true;


	protected override async Task Run(Args args)
	{
		int rand = RandomProbability();

		Actions actions = this.ListOfActions[rand].m_Action;
		Debug.Log(actions.name);
		if (actions == null) return;

		if (this.m_WaitToFinish) await actions.Run(args);
		else _ = actions.Run(args);

         
	}
	
	public int RandomProbability()
	{

		int weightTotal = 0;
		if (ListOfActions.Capacity > 0)
		{
			for (int i = 0; i < ListOfActions.Capacity; i++)
			{
				if(ListOfActions[i].Probability==0) ListOfActions[i].Probability=1;
				weightTotal += ListOfActions[i].Probability;
			}

			int result = 0, total = 0;
			int randVal = UnityEngine.Random.Range(0, weightTotal);

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