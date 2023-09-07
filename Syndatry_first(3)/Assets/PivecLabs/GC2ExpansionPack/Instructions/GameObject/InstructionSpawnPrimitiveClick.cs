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
[Title("Spawn Primitive at Mouse")]
[Description("Spawns a Primitve at the specified Mouse position")]
[Category("Game Objects/Spawn Primitive at Mouse")]

[Parameter("Primitive", "Primitive reference that is spawned")]
[Parameter("Position", "The scene location used to spawn the primitive")]

[Keywords("Spawn", "Primitive", "Cube", "Sphere", "Capsule", "Plane", "Cylinder")]
[Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]

[Serializable]
	public class InstructionSpawnPrimitiveClick : Instruction
{
	public override string Title => $"Spawn Primitive {this.primitiveType} at Mouse";



	public enum primitive
	{
		Cube,
		Sphere,
		Capsule,
		Cylinder,
		Plane,
		Quad
	}
	public primitive primitiveType = primitive.Cube;
	private GameObject go;
	private Mouse mouse;
	private float mZCoord;

	[SerializeField]public PropertyGetPosition offset = new PropertyGetPosition();
	[SerializeField]public PropertyGetScale size = new PropertyGetScale(new Vector3(1f,1f,1f));
		[SerializeField] private PropertySetGameObject m_Save = SetGameObjectNone.Create;

		protected override Task Run(Args args)
	{
		mouse = InputSystem.GetDevice<Mouse>();
		Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
		RaycastHit hit;


		switch (this.primitiveType)
		{
		case primitive.Cube: 
			go = GameObject.CreatePrimitive(PrimitiveType.Cube);
			break;
		case primitive.Sphere: 
			go = GameObject.CreatePrimitive(PrimitiveType.Sphere);	
			break;
		case primitive.Capsule: 
			go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			break;
		case primitive.Cylinder: 
			go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);	
			break;
		case primitive.Plane: 
			go = GameObject.CreatePrimitive(PrimitiveType.Plane);
			break;
		case primitive.Quad: 
			go = GameObject.CreatePrimitive(PrimitiveType.Quad);
			break;
		}  
		Vector3 offsetPosition = this.offset.Get(args);
		Vector3 valueSize = this.size.Get(args);

		if (go == null) return DefaultResult;

		go.transform.localScale = valueSize;
		
		if (Physics.Raycast(ray, out hit))
		{
			go.transform.position = new Vector3(hit.point.x +offsetPosition.x,hit.point.y +offsetPosition.y,hit.point.z +offsetPosition.z );
		

		}
			this.m_Save.Set(go, args);

			return DefaultResult;
		}
	}

}