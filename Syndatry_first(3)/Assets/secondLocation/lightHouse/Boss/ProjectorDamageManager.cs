using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorDamageManager : MonoBehaviour
{

    [SerializeField] private float range;
    [SerializeField] private float damagePerFixedUpdate;
    [SerializeField] private float force;
    [SerializeField] private ForestBossAi boss;

    void DamageBoss()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        bool isHit = Physics.Raycast(ray, out hit, range);
        if (isHit)
        {
            Collider hitObject = hit.collider;
            if (hitObject.CompareTag("ForestBoss"))
            {
                if (hitObject.TryGetComponent<BossHealthManager>(out BossHealthManager bossHealthManager))
                {
                    bossHealthManager.TakeDamage(damagePerFixedUpdate);
                    boss.defend = true;
                }
            }
        } else
        {
            boss.defend = false;
        }
    }

    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("ForestBoss").GetComponent<ForestBossAi>();
    }

    private void FixedUpdate()
    {
        DamageBoss();
    }
}
