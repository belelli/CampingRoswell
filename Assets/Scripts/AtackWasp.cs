using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackWasp : MonoBehaviour
{
    public float damage = 10f; 
    public float attackRange = 5f; 
    public float attackCooldown = 2f; 

    private float lastAttackTime;

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerAtackWasp.instance.transform.position) < attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        PlayerAtackWasp.instance.TakeDamage(damage);
    }
}
