using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProjectorDamageManager : MonoBehaviour
{

    private bool canHit = false;
    [SerializeField] private float damagePerFixedUpdate;

    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ForestBoss")
        {
            canHit = true;
            boss = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ForestBoss")
        {
            canHit = false;
        }
    }

    private void FixedUpdate()
    {
        if (canHit)
        {
            boss.GetComponent<BossHealthManager>().TakeDamage(damagePerFixedUpdate);
        }
    }
}
