using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{
    public Transform player; // Referencia al transform del jugador
    public float attackRange = 5f; // Rango de ataque

    private void Update()
    {

        DetectingPlayer();


        /* if (Vector3.Distance(transform.position, player.position) <= range)
        {
            AttackPlayer();
        }
        */
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
