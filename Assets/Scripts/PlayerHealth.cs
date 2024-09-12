using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Salud inicial del jugador

    public void TakeDamage(int damage)
    {
       
        health -= damage;

       
        if (health <= 0)
        {
            Die();
            

            
        }
    }

    private void Die()
    {
      
        Debug.Log("Player is dead!");
        Time.timeScale = 0;
    }
}
