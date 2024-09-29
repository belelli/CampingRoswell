using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvispaFollow : MonoBehaviour
{
    public Transform player; 
    public float followRange = 5f; 
    public float moveSpeed = 1f; 

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer < followRange)
        {
            FollowPlayer();
            LookAtPlayer();
        }
    }

    void FollowPlayer()
    {

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void LookAtPlayer()
    {

        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 80, 0); 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);
    }
}
