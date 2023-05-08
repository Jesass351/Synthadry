using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 500;
    
    
    public void GetDamage(float damage, float multiply)
    {
        this.health -= damage * multiply;
        if (this.health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
