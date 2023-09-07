using System;
using System.Threading.Tasks;
using UnityEngine;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Spawn Prefab at Position")]
[Description("Spawns a Prefab at the specified position")]
[Category("Game Objects/Spawn Prefab at Position")]

[Parameter("Prefab", "Prefab reference that is spawned")]
[Parameter("Position", "The scene location used to spawn the Prefab")]
	[Parameter("Save", "Optional value where the newly instantiated game object is stored")]

	[Keywords("Spawn", "Prefab", "Mouse")]
[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]

[Serializable]
	public class InstructionSpawnPrefab : Instruction
{
	public override string Title => $"Spawn Prefab to {this.position}";

	
	[SerializeField]public GameObject prefabToUse;
	[SerializeField]public PropertyGetPosition position = new PropertyGetPosition();
	[SerializeField]public PropertyGetScale size = new PropertyGetScale(new Vector3(1f,1f,1f));
	[SerializeField] private PropertySetGameObject m_Save = SetGameObjectNone.Create;


		private GameObject go;

	protected override Task Run(Args args)
	{
		
		go = this.prefabToUse;
		Vector3 valuePosition = this.position.Get(args);
		Vector3 valueSize = this.size.Get(args);

		if (go == null) return DefaultResult;

		go.transform.localScale = valueSize;

		go.transform.position = valuePosition;
		
		GameObject.Instantiate(go);
		this.m_Save.Set(go, args);


			return DefaultResult;
	}
}
}