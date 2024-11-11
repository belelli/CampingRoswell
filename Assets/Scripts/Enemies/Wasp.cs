using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{
    private Animator _animator;
    [SerializeField] AnimationCurve myCurve;

    private float lastAttackTime;

    public PlayerAtackWasp players;

    
    

    public void Update()
    {
        chase();


        if (Vector3.Distance(transform.position, playerPosition.transform.position) < attackRange)
        {

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                attack();
                lastAttackTime = Time.time;
                
            }
        }
    }

    public override void attack()
    {
        if (PlayerAtackWasp.currentHealth >= 1) 
        { 
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                players.TakeDamage(damage);
                animator.SetBool("IsAttacking", false);
                currentState = EnemyState.Chase; // Regresar a Chase después de atacar
            }

        }
        else { currentState = EnemyState.Idle; }
    }

    /*public void levitateAnim()
    {        
       
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);

    }*/

}
