using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAtackWasp : MonoBehaviour
{
    public static PlayerAtackWasp instance; 
    public int health = 100;

    

    [SerializeField] private HealthBar healthbar;
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private float maxHealth = 100f; // Valor máximo de vida
    [SerializeField] private Transform player;

    public static float currentHealth; // Variable para la salud actual - Carlos: lo cambié a publico y static para acceder a este valor desde todo lado

    Animator sAnimator;

    Enemy enemy; //Carlos: para acceder al script de enemigo y que cambie el state
    
    void Start()
    {
        currentHealth = maxHealth; 
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
        sAnimator = GetComponentInChildren<Animator>();
        
    }

    

    public void TakeDamage(int amount)
    { 
        currentHealth -= amount;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
        sAnimator.SetBool("Stunt", true);


        Debug.Log("¡Has sido picado! Salud restante: " + currentHealth);
        

        if (currentHealth <= 0)
        {
            sAnimator.SetTrigger("Death");
            enemy.currentState = Enemy.EnemyState.Idle; //Carlos: entro al script y le digo que cambie a idle
            Debug.Log("IDLE");//debuggear que ande
            
            
        }
    }

    public static void Die() //Carlos: cambié a static para llamarlo desde otro script
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(3);


    }

    
}
