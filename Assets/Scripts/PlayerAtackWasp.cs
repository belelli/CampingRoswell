using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtackWasp : MonoBehaviour
{
    public static PlayerAtackWasp instance; 
    public float health = 100f; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("¡Has sido picado! Salud restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("El jugador ha muerto.");
        Time.timeScale = 0;


    }
}
