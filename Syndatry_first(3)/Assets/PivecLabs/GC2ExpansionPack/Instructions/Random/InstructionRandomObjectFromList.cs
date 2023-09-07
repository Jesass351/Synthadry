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
[Title("Set Active Random Object From List")]
[Description("Set Active Random Object From List")]
[Category("Random/Set Active Random Object From List")]


[Keywords("Object", "Active", "Random")]
[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]
[AddComponentMenu("")]
[Serializable]
	public class InstructionRandomObjectFromList : Instruction
	{
	public override string Title => string.Format(
	"Set Active Random Object From List");
	
	
		[System.Serializable]
		public class ActionGObject
		{
			public GameObject target;
           
			[Range(1,100)] public int Probability = 100;
		
		}

		[SerializeField]private List<ActionGObject> ListofObjects = new List<ActionGObject>();

		[SerializeField]private bool active = true;
		[SerializeField]private bool leaveactive = true;
		
	protected override Task Run(Args args)
		{
		
			GameObject targetValue;
		
		if (leaveactive == false)
		{
			if (ListofObjects.Capacity > 0)
			{
				for (int i = 0; i < ListofObjects.Capacity; i++)
				{
					targetValue = ListofObjects[i].target;
					if (targetValue != null) targetValue.SetActive(!this.active);

				}
			}
		}
		   
			
		int rand = RandomProbability();
                
		targetValue = ListofObjects[rand].target;
		if (targetValue != null) targetValue.SetActive(this.active);

			return DefaultResult;
         
	}
		public int RandomProbability()
		{

			int weightTotal = 0;
			if (ListofObjects.Capacity > 0)
			{
				for (int i = 0; i < ListofObjects.Capacity; i++)
				{
					if(ListofObjects[i].Probability==0) ListofObjects[i].Probability=1;
					weightTotal += ListofObjects[i].Probability;
				}

				int result = 0, total = 0;
				int randVal = UnityEngine.Random.Range(0, weightTotal);

				for (result = 0; result < ListofObjects.Capacity; result++)
				{
					total += ListofObjects[result].Probability;
					if (total > randVal) break;
				}

				return result;

			}
			return 0;
		}
	}
}