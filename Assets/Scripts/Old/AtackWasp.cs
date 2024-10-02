using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackWasp : MonoBehaviour
{
    public int damage = 10; 
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