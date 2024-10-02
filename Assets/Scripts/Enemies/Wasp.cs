using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{

    [SerializeField] AnimationCurve myCurve;

    private float lastAttackTime;



    public void Update()
    {
        chase();


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

    public void levitateAnim()
    {        
       
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);

    }

}
