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
    [Title("Set Bool Variable with Random Value")]
    [Description("Set Bool Variable with Random Value")]
    [Category("Random/Set Bool Variable with Random Value")]

    [Keywords("Bool", "Variable", "Random")]
    [Image(typeof(IconInstructions), ColorTheme.Type.Blue)]


    [Serializable]

	public class InstructionRandomBoolVariable : Instruction
    {


	    [SerializeField]private PropertySetBool m_variable = new PropertySetBool();


        public override string Title => "Set Bool Variable with Random Value";


		protected override Task Run(Args args)
		{
   
			bool randomBool = UnityEngine.Random.value > 0.5;
			
			this.m_variable.Set(randomBool, args);
           
            return DefaultResult;
        }
     

            
   
		
	}
}