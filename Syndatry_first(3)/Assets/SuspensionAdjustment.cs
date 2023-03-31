using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspensionAdjustment : MonoBehaviour
{
    public float springStrength;
    public float damperStrength;

    private WheelCollider[] wheelColliders;

    private void Start()
    {
        wheelColliders = GetComponentsInChildren<WheelCollider>();
        UpdateSuspension();
    }

    public void UpdateSuspension()
    {
        foreach (WheelCollider wheel in wheelColliders)
        {
            JointSpring spring = wheel.suspensionSpring;

            spring.spring = springStrength;
            spring.damper = damperStrength;

            wheel.suspensionSpring = spring;
        }
    }
}