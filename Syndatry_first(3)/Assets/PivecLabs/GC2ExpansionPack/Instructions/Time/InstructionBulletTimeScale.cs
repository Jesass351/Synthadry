using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Bullet Time Scale")]
    [Description("InstrucBullet Time ScaletionTemplate")]
    [Category("Time/Bullet Time Scale")]

  
    [Keywords("Time", "BulletTime")]
    [Image(typeof(IconTimer), ColorTheme.Type.Blue)]


    [Serializable]

    public class InstructionBulletTimeScale : Instruction
    {


   
	    [SerializeField]private PropertyGetDecimal m_TimeScale = new PropertyGetDecimal(0.2f);
  
	    [SerializeField][Range(0f, 5f)]private float transitionDuration = 1.0f;
	    [SerializeField][Range(0f, 5f)]private float ElapsedBulletTime = 1.0f;
	    [SerializeField] private int m_Layer = 0;

   

        public override string Title => "Bullet Time Scale";


	    protected override async Task Run(Args args)
		{
			float bullettimeScale = (float) this.m_TimeScale.Get(args);
	
			TimeManager.Instance.SetSmoothTimeScale(
				bullettimeScale,
				this.transitionDuration,
				this.m_Layer
			);
     
			float value = (float) this.ElapsedBulletTime;
			await this.Time(value);
            
			TimeManager.Instance.SetSmoothTimeScale(
				1,
				this.transitionDuration,
				this.m_Layer
			);
		}
		
	}
}