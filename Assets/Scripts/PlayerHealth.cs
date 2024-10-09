using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
       
        health -= damage;

       print("salud " +  health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
      
        Debug.Log("Player is dead!");
        SceneManager.LoadScene(1);
    }
}
