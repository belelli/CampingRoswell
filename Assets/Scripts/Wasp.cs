using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{
    public Transform player; // Referencia al transform del jugador
   // public float Speed = 5f; // Velocidad de movimiento de la avispa
    //public float attackRange = 1f; // Rango de ataque
    // public int damage = 10; // Daño que hace la avispa

    private void Update()
    {

        MoveTowardsPlayer();


        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            AttackPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;
    }

    private void AttackPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(dmg);
        }
    }
}
