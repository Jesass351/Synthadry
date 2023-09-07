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
    [Title("Set Color Variable with Random Value")]
    [Description("Set Color Variable with Random Value")]
    [Category("Random/Set Color Variable with Random Value")]

    [Keywords("Color", "Variable", "Random")]
    [Image(typeof(IconInstructions), ColorTheme.Type.Blue)]


    [Serializable]

	public class InstructionRandomColorVariable : Instruction
    {


	    [SerializeField]private PropertySetColor m_variable = new PropertySetColor();


	    public override string Title => "Set Color Variable with Random Value";


		protected override Task Run(Args args)
		{
   
			Color randomColor = UnityEngine.Random.ColorHSV();
			
			this.m_variable.Set(randomColor, args);
           
            return DefaultResult;
        }
     

            
   
		
	}
}