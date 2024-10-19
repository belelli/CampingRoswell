using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthBar healthbar;
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Transform player;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud actual al máximo
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);

        Debug.Log("Salud: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("¡El jugador ha muerto!");
        SceneManager.LoadScene(3); // Cambia a la escena de muerte
    }
}
