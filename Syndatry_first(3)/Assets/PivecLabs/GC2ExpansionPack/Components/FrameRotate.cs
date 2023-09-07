using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.Audio;
using GameCreator.Runtime.VisualScripting;

namespace PivecLabs.GameCreator.VisualScripting
{
	
	
public class FrameRotate : MonoBehaviour
{
	private Transform target;
	private Transform pointer;
	public bool rotatingFrame;

	void Start()
    {
			target = GameObject.Find("Player").transform;
		}
    void Update()
    {
        
	    if (rotatingFrame == true) 
	    {
		    Vector3 frameAngle = new Vector3();
		    frameAngle.z = target.transform.eulerAngles.y;
		    this.transform.eulerAngles = frameAngle;		    
	    }

		else if (rotatingFrame == false)
			{
				this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

			}

		}
	}
}

