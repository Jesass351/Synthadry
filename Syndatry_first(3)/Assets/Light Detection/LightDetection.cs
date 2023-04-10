using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    private Light m_light;
    private SphereCollider m_sphereCollider;
    private bool isInRadius;

    public float darkness;

    [SerializeField]
    private float m_updateTime = .1f;

    void Start()
    {
        m_light = GetComponent<Light>();
        m_sphereCollider = GetComponent<SphereCollider>();
        m_sphereCollider.radius = m_light.range;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            isInRadius = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isInRadius = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 playerPosition = other.transform.position;
            playerPosition.y = m_light.transform.position.y;
            darkness = 1 - ((playerPosition - transform.position).magnitude/m_light.range);
            if (darkness < 0)
                darkness = 0;
            Debug.Log("Darkness:" + darkness);
        }
    }

}

