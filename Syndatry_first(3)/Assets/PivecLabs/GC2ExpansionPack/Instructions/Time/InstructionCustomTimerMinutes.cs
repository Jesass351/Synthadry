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
    [Title("Custom Timer in Minutes")]
    [Description("Custom Timer for calling Actions and Conditions")]
    [Category("Time/Custom Timer in Minutes")]

 
    [Keywords("Timer", "Actions", "Conditions")]
    [Image(typeof(IconTimer), ColorTheme.Type.Blue)]


    [Serializable]

	public class InstructionCustomTimerMinutes : Instruction
    {
	    [SerializeField][Range(1f, 60f)]private float m_Minutes = 10.0f;
	    [SerializeField] private bool executeOnFinish = false;

    		public enum RESULT
	    {
		    Action,
		    Condition
	    }
	    [SerializeField] private RESULT result = RESULT.Action;

	    public Actions actionToCall;
	    public Conditions conditionToCall;


	    public override string Title => "Custom Timer in Minutes";


	    protected override async Task Run(Args args)
		{
			float value = (float) this.m_Minutes;
			await this.Time(value * 60);
         
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
}