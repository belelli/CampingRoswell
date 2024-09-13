using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{
    //public Transform player; // Referencia al transform del jugador //Lo comento por que no es necesario crear esta l�nea, ya tenemos de herencia la linea playerPosition y a ella nos debemos referir en el c�digo
    //public float attackRange = 5f; // Rango de ataque// Lo comento por que no veo donde lo usamos, despues lo chequeamos
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {           
            AttackPlayer(); 
        }
    }

    

    public void Update()
    {

        DetectingPlayer();

        
        /*if (Vector3.Distance(transform.position, playerPosition.position) <= range)
        {
            AttackPlayer();
        }*/

        
        
    }

    public void AttackPlayer()
    {
        PlayerHealth playerHealth = playerPosition.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(dmg);
            Debug.Log("Te comiste " + dmg);
        }
    }
    
}
