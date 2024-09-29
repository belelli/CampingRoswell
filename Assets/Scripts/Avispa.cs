using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avispa : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float speed = 5f; // Velocidad de movimiento de la avispa

    private void Update()
    {
        
        MoveTowardsPlayer();

       
    }

    private void MoveTowardsPlayer()
    {
       
        Vector3 direction = (player.position - transform.position).normalized;
        
        transform.position += direction * speed * Time.deltaTime;
    }

}
