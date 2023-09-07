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
using PivecLabs.MinMaxSliderInt;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Set Vector3 Variable with Random Value")]
    [Description("Set Vector3 Variable with Random Value")]
    [Category("Random/Set Vector3 Variable with Random Value")]

    [Keywords("Vector3", "Variable", "Random")]
    [Image(typeof(IconInstructions), ColorTheme.Type.Blue)]


    [Serializable]

	public class InstructionRandomVector3Variable : Instruction
    {

	    [SerializeField]
	    [MinMaxInt(-100, 100)]
	    public MinMaxint xLimits;

	    [SerializeField]
	    [MinMaxInt(-100, 100)]
	    public MinMaxint yLimits;

	    [SerializeField]
	    [MinMaxInt(-100, 100)]
	    public MinMaxint zLimits;


	    [SerializeField]private PropertySetVector3 m_variable = new PropertySetVector3();


        public override string Title => "Set Vector3 Variable with Random Value";


		protected override Task Run(Args args)
		{
   
			Vector3 randomPosition = new Vector3(
				UnityEngine.Random.Range(xLimits.min, xLimits.max),
				UnityEngine.Random.Range(yLimits.min, yLimits.max),
				UnityEngine.Random.Range(zLimits.min, zLimits.max)
			);
			
			this.m_variable.Set(randomPosition, args);
           
            return DefaultResult;
        }
     

            
   
		
	}
}