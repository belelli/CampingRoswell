using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Centipede : Enemy
{
    /*public float detectionRange = 5f;
    public Transform playerPosition;
    public float speed = 2;
    private NavMeshAgent agent;
    */
    // Start is called before the first frame update
    void Start()
    {
        // agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectingPlayer();
    }

    /*public void DetectingPlayer() 
    {
        float distance = Vector3.Distance(playerPosition.position,transform.position);

        if (distance <= detectionRange) 
        {
            //Vector3 direction = (playerPosition.position - transform.position).normalized;
            //transform.position += direction * speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
            agent.SetDestination(playerPosition.position);
        }
    }
    */

    
}
