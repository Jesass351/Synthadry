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
using PivecLabs.CustomTagSelector;

namespace PivecLabs.GameCreator.VisualScripting
{

    [Version(1, 0, 1)]
    [Title("Drag Object by Tag with Mouse")]
    [Description("Drag Object by Tag with Mouse")]
    [Category("Game Objects/Drag Object by Tag with Mouse")]

    [Parameter("m_Tag", "The Tag of the Game Object to be Dragged")]

    [Keywords("Object", "Drag", "Mouse", "Tag")]
    [Image(typeof(IconRotation), ColorTheme.Type.Yellow)]


    [Serializable]

    public class InstructionDragObjectByTag : Instruction
    {



		[SerializeField][TagSelector] public string tagStr = "";
		private GameObject objectToDrag;

		[SerializeField] public bool restrictDragging;

        [SerializeField] public bool xAxis = false;
        [SerializeField] public bool yAxis = false;
        [SerializeField] public bool zAxis = false;

        private Vector3 rotateAxis;
        private GameObject objectToRotate;
        public override string Title => "Drag Object by Tag with Mouse";
	    private Mouse mouse;
	    private Vector3 speed = Vector3.zero;
	    private Vector2 lastMousePosition = Vector2.zero;
	    private bool dragging;
	    private Rigidbody r;

	
	    private Vector3 mOffset;
	    private float mZCoord;


        protected override  Task Run(Args args)
	    {

	
			mouse = InputSystem.GetDevice<Mouse>();
			Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
			RaycastHit hit;
			    if(Physics.Raycast (ray,out hit, 100.0f))
			    {
				if (hit.transform.gameObject.tag == this.tagStr)
				{
						dragging = true;
						objectToDrag = hit.transform.gameObject;
					    mZCoord = Camera.main.WorldToScreenPoint(objectToDrag.transform.position).z;
					}

				if (dragging == true)
				{
					if (lastMousePosition == Vector2.zero) lastMousePosition = mouse.position.ReadValue();
					var mouseDelta = ((Vector2)mouse.position.ReadValue() - lastMousePosition) * 100;
					mouseDelta.Set(mouseDelta.x / Screen.width, mouseDelta.y / Screen.height);
					if ((restrictDragging == true) && (hit.transform.gameObject.tag == this.tagStr))
					{
						if (xAxis == true)
						{
							Vector3 newYposition = GetMouseAsWorldPoint();
							objectToDrag.transform.position = new Vector3(objectToDrag.transform.position.x, newYposition.y, objectToDrag.transform.position.z);
						}
						if (yAxis == true)
						{
							Vector3 newXposition = GetMouseAsWorldPoint();
							objectToDrag.transform.position = new Vector3(newXposition.x, objectToDrag.transform.position.y, objectToDrag.transform.position.z);
						}
						if (zAxis == true)
						{
							Vector3 newZposition = GetMouseAsWorldPoint();
							objectToDrag.transform.position = new Vector3(objectToDrag.transform.position.x, objectToDrag.transform.position.y, newZposition.z);
						}
					}
					else if (hit.transform.gameObject.tag == this.tagStr)
					{
						objectToDrag.transform.position = GetMouseAsWorldPoint();
					}
					lastMousePosition = mouse.position.ReadValue();
				}
			}
	
			return DefaultResult;
        }
     
	    private Vector3 GetMouseAsWorldPoint()
	    {
		    Vector3 mousePoint = mouse.position.ReadValue();
		    mousePoint.z = mZCoord;
		    return Camera.main.ScreenToWorldPoint(mousePoint);

	    }
	    
	  
       
    }
}