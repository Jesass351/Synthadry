using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

[Version(1, 0, 1)]
[Title("Spawn Prefab at Mouse")]
[Description("Spawns a Prefab at the specified Mouse position")]
[Category("Game Objects/Spawn Prefab at Mouse")]

[Parameter("Prefab", "Prefab reference that is spawned")]
[Parameter("Position", "The scene location used to spawn the Prefab")]

[Keywords("Spawn", "Prefab", "Mouse")]
[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]

[Serializable]
	public class InstructionSpawnPrefabClick : Instruction
{
	public override string Title => $"Spawn Prefab at Mouse";

	
	[SerializeField]public GameObject prefabToUse;
	[SerializeField]public PropertyGetPosition offset = new PropertyGetPosition();
	[SerializeField]public PropertyGetScale size = new PropertyGetScale(new Vector3(1f,1f,1f));
		[SerializeField] private PropertySetGameObject m_Save = SetGameObjectNone.Create;

		private GameObject go;
	private Mouse mouse;
	private float mZCoord;

	protected override Task Run(Args args)
	{
		mouse = InputSystem.GetDevice<Mouse>();
		Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
		RaycastHit hit;
		
		go = this.prefabToUse;
		Vector3 offsetPosition = this.offset.Get(args);
		Vector3 valueSize = this.size.Get(args);

		if (go == null) return DefaultResult;

		go.transform.localScale = valueSize;

		if (Physics.Raycast(ray, out hit))
		{
			go.transform.position = new Vector3(hit.point.x +offsetPosition.x,hit.point.y +offsetPosition.y,hit.point.z +offsetPosition.z );
		

		}		
		GameObject.Instantiate(go);
			this.m_Save.Set(go, args);


			return DefaultResult;
	}
}
}