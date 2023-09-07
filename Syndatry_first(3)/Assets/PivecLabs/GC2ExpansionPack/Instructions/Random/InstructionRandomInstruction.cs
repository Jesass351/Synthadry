using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{
 
[Version(1, 0, 1)]
[Title("Execute Random Instruction")]
[Description("Executes a Random Instruction from a set of 4")]
[Category("Random/Execute Random Instruction")]

[Parameter("Actions", "The Actions to be executed at Random")]

[Keywords("Execute", "Call", "Instruction", "Random")]
[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]

[Serializable]
public class InstructionRandomInstruction : Instruction
{
	public override string Title => string.Format(
	"Execute 1 of 4 Random Actions{0}", this.m_WaitToFinish ? " and wait" : string.Empty	);
	[SerializeField] private bool m_WaitToFinish = true;

	[SerializeField] private PropertyGetGameObject actions1 = GetGameObjectActions.Create();
	[SerializeField] private PropertyGetGameObject actions2 = GetGameObjectActions.Create();
	[SerializeField] private PropertyGetGameObject actions3 = GetGameObjectActions.Create();
	[SerializeField] private PropertyGetGameObject actions4 = GetGameObjectActions.Create();
 
	private Actions actions;

	protected override async Task Run(Args args)
	{
		float randomVar = UnityEngine.Random.Range(1, 5); 
		switch (randomVar)
		{
		case 1:
			actions = this.actions1.Get<Actions>(args);
			if (actions == null) return;

			break;
		case 2:
			actions = this.actions2.Get<Actions>(args);
			if (actions == null) return;
			break;
		case 3:
			actions = this.actions3.Get<Actions>(args);
			if (actions == null) return;
			break;
		case 4:
			actions = this.actions4.Get<Actions>(args);
			if (actions == null) return;

			break;
		}
		if (this.m_WaitToFinish) await actions.Run(args);
		else _ = actions.Run(args);

         
	}

}
}