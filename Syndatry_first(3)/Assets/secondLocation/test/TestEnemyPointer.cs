using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyPointer : MonoBehaviour
{
    [SerializeField] private GameObject enemyClone;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            enemyClone.SetActive(true);
        };
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            enemyClone.SetActive(false);
        }
    }
}
