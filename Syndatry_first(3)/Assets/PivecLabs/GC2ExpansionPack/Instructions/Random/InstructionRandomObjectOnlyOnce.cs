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
[Title("Set Active Random Object From List only Once")]
[Description("Set Active Random Object From List only Once")]
[Category("Random/Set Active Random Object From List only Once ")]


[Keywords("Active", "Object", "Once", "Random")]
[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]

[Serializable]
public class InstructionRandomObjectOnlyOnce : Instruction
	{
	public override string Title => string.Format(
	"Set Active Random Object From List only Once");
	
	
		[System.Serializable]
		public class ActionGObject
		{
			public GameObject target;
           
			[Range(1,100)] public int Probability = 100;
		
		}

		[SerializeField]private List<ActionGObject> ListofObjects = new List<ActionGObject>();
		 [SerializeField]public List<ActionGObject> OriginalListofObjects;


		[SerializeField]private bool active = true;
		[SerializeField]private bool leaveactive = true;	    
		
		public bool repeatatend = true;

		private GameObject targetValue;
	    
		private bool repeat = false;
		private int rand;
		private int randTotal;

		private bool once = true;
		private int listcount;


		protected override Task Run(Args args)
		{
			
		if (once)
		{
			OriginalListofObjects = new List<ActionGObject>(ListofObjects);
			once = false;
			listcount = ListofObjects.Capacity;
		}
		    
		if (repeatatend == true)
		{
			if (listcount == 0)
			{
				ListofObjects = new List<ActionGObject>(OriginalListofObjects);
				repeat = false;
				listcount = ListofObjects.Capacity;

			} 
		}
		    
		if (leaveactive == false)
		{
			if (targetValue != null) targetValue.SetActive(!this.active);

		}
		    
	
		if (repeat == false)
		{
			rand = UnityEngine.Random.Range(0, ListofObjects.Capacity);
			randTotal = ListofObjects.Capacity;
	
		}

		else if (repeat == true)

		{
                
			rand = UnityEngine.Random.Range(0, randTotal);
			    
	
		}
	    	

		    
		if (randTotal > 0)
		{
  

			targetValue = ListofObjects[rand].target;
			if (targetValue != null) targetValue.SetActive(this.active);
	
			ListofObjects.RemoveAt(rand);
			randTotal = (randTotal - 1);
			repeat = true;
			listcount = (listcount - 1);

		}
		    
			return DefaultResult;
	
	}
		
		

	}
}