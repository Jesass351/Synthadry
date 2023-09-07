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
[Title("Execute Random Instruction only Once")]
[Description("Executes a Random Instruction only Once from a List")]
[Category("Random/Execute Random Instruction only Once from List")]


[Keywords("Execute", "Call", "Instruction", "Random")]
[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]

[Serializable]
public class InstructionRandomInstructionOnlyOnce : Instruction
	{
	public override string Title => string.Format(
	"Execute Random Instruction only Once");
	
		[System.Serializable]
		public class ActionsObject
		{
			public Actions m_Action;
			[Range(1,100)] public int Probability = 100;
		}

		[SerializeField] private List<ActionsObject> ListOfActions = new List<ActionsObject>();
		[SerializeField] private bool m_WaitToFinish = true;
		[SerializeField] private bool executeOnFinish = false;

		
		public enum RESULT
		{
			Action,
			Condition
		}
		[SerializeField] private RESULT result = RESULT.Action;

		public Actions actionToCall;
		public Conditions conditionToCall;

		private int randTotal;
		private bool repeat = false;
		private int rand;
		protected override async Task Run(Args args)
		{
		
		
			if (repeat == false)
			{
				rand = UnityEngine.Random.Range(0, ListOfActions.Capacity);
				randTotal = ListOfActions.Capacity;
			}

			else if (repeat == true)

			{

				rand = UnityEngine.Random.Range(0, randTotal);
			}
			
			if (randTotal > 0)
			{
				

				Actions actions = this.ListOfActions[rand].m_Action;

				if (actions == null) return;

				if (this.m_WaitToFinish) await actions.Run(args);
				else _ = actions.Run(args);


				ListOfActions.RemoveAt(rand);
				randTotal = (randTotal - 1);
				repeat = true;

			}
			else
			{
				if (executeOnFinish)
				{
				switch (this.result)
				{
					case RESULT.Action:
						Actions actions = this.actionToCall;
						if (actions == null) return;
							await actions.Run(args);
							break;
					case RESULT.Condition:
						Conditions conditions = this.conditionToCall;
						if (conditions == null) return;
							 await conditions.Run(args);
							 break;

				}
				}
			}

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