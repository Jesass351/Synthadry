using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent Enemy;
    private GameObject Player;

    [SerializeField] private HealthManager heroHealthManager;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float DistationPlayer = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if (DistationPlayer < 60) {
            if (DistationPlayer < 3) {
                
            } else {
                Enemy.SetDestination(Player.transform.position);
            }
        }
    }
}
