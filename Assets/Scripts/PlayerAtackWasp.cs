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

    private float currentHealth; // Variable para la salud actual

    Animator sAnimator;

    public GameObject _spider; //para llamar al script de la araña
    CapsuleCollider _cc;
    void Start()
    {
        currentHealth = maxHealth; 
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
        sAnimator = GetComponentInChildren<Animator>();
        _cc = GetComponent<CapsuleCollider>();
    }

    

    public void TakeDamage(int amount)
    { 
        currentHealth -= amount;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);
        sAnimator.SetBool("Stunt", true);


        Debug.Log("¡Has sido picado! Salud restante: " + currentHealth);
        

        if (currentHealth <= 0)
        {
            _spider.GetComponent<Spider>().enabled = false;//entro en el script de la araña y la desactivo para que no siga disparando
            Debug.Log("IDLE");//debuggear que ande
            _cc.isTrigger = true;
            sAnimator.SetTrigger("Death");
        }
    }

    public void Die()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(3);


    }

    
}
