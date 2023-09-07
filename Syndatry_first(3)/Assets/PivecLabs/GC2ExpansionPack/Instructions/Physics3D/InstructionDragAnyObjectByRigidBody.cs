using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Drag Any Object by RigidBody with Mouse")]
    [Description("Drag Any Object by RigidBody with Mouse")]
    [Category("Physics 3D/Drag Any Object by RigidBody with Mouse")]

    [Keywords("Object", "Drag", "Mouse")]
    [Image(typeof(IconRotation), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionDragAnyObjectByRigidBody : Instruction
    {
	 
        private Vector3 rotateAxis;
        private GameObject objectToRotate;
        public override string Title => "Drag Any Object by RigidBody with Mouse";
	    private Mouse mouse;
	    private Vector3 speed = Vector3.zero;
	    private Vector2 lastMousePosition = Vector2.zero;
	    private bool dragging;
	    private Rigidbody r;

	
	    private Vector3 mOffset;
	    private float mZCoord;


		public float forceAmount = 10;

		private Rigidbody selectedRigidbody;
		private Vector3 originalScreenTargetPosition;
		private Vector3 originalRigidbodyPos;
		private float selectionDistance;
		private Vector3 mousePoint;

		protected override  async Task Run(Args args)
	    {

			mouse = InputSystem.GetDevice<Mouse>();
			mousePoint = mouse.position.ReadValue();
			selectedRigidbody = GetRigidbodyFromMouseClick();
			Debug.Log(originalRigidbodyPos);

			await insertDelay();

			if (selectedRigidbody)
					{

					mousePoint = mouse.position.ReadValue();

					Vector3 mousePositionOffset = Camera.main.ScreenToWorldPoint(new Vector3(mousePoint.x, mousePoint.y, selectionDistance)) - originalScreenTargetPosition;

					selectedRigidbody.velocity = (originalRigidbodyPos + mousePositionOffset - selectedRigidbody.transform.position) * forceAmount;

				//	Debug.Log(mousePositionOffset);
			}
			
        }

		Rigidbody GetRigidbodyFromMouseClick()
		{
			RaycastHit hit = new RaycastHit();

			Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
			if (Physics.Raycast(ray, out hit))
			{
				if ((hit.collider.gameObject.GetComponent<Rigidbody>()))
				{
					selectionDistance = Vector3.Distance(ray.origin, hit.point);
					originalScreenTargetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePoint.x, mousePoint.y, selectionDistance));
					originalRigidbodyPos = hit.collider.transform.position;
					return hit.collider.gameObject.GetComponent<Rigidbody>();
				}
			}
			return null;

		}

		public async Task insertDelay()
		{
			await this.NextFrame();
		}
	}
	}