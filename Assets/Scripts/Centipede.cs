using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : Enemy
{
    public float detectionRange = 5f;
    public Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        DetectingPlayer();
        LookAtPlayer();
    }

    public void DetectingPlayer() 
    {
        float distance = Vector3.Distance(transform.position, playerPosition.position);

        if (distance <= detectionRange) 
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
        }
    }

    public void LookAtPlayer() 
    {
        Quaternion lockOn = Quaternion.LookRotation(playerPosition.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lockOn, Time.deltaTime);
    }
}
